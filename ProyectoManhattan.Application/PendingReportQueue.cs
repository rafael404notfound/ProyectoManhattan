using Microsoft.Extensions.Hosting;
using System.Net;
using Microsoft.Playwright;
using ProyectoManahttan.Domain.ValueTypes;
using Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.SignalR;
using ProyectoManahttan.Application;

namespace ProyectoManhattan.Application
{
    public class PendingReportQueue : BackgroundService
    {
        private static readonly TimeSpan Period = TimeSpan.FromSeconds(3);
        private static Queue<PendingReport> _pendingReports = new Queue<PendingReport>();
        private EciService _eciService { get; set; }
        private IJwtGetter _jwtGetter { get; set; }
        private IReportRepo? _reportRepo { get; set; }
        private PdfEditor _pdfEditor { get; set; }
        private IServiceProvider _serviceProvider { get; set; }
        private IHubContext<NotificationHub, INotificationClient> _context { get; set; }

        public PendingReportQueue(EciService eciService, IJwtGetter jwtGetter, PdfEditor pdfEditor, IServiceProvider serviceProvider, IHubContext<NotificationHub, INotificationClient> context)
        {
            _eciService = eciService;
            _jwtGetter = jwtGetter; 
            _pdfEditor = pdfEditor;
            _serviceProvider = serviceProvider;
            _context = context;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Console.WriteLine($"---> PENDING REPORT QUEUE STARTED");
            using var timer = new PeriodicTimer(Period);
            while(!stoppingToken.IsCancellationRequested && await timer.WaitForNextTickAsync(stoppingToken))
            {
                Console.WriteLine($"---> HEY");
                if(_pendingReports.Count() > 0)
                {
                    GetScopedServices();

                    var httpClientHandler = new HttpClientHandler { CookieContainer = _jwtGetter.cookieContainer };
                    var httpClient = new HttpClient(httpClientHandler); 

                    Console.WriteLine($"---> STARTING {_pendingReports.First().ReportName} REPORT CALCULATION");
                    var newReport = _eciService.CalculateReport(_pendingReports.First(), httpClient);
                    newReport.Base64Pdf = _pdfEditor.CreatePdf(newReport);
                    Console.WriteLine($"---> FINISHED {_pendingReports.First().ReportName} REPORT CALCULATION");

                    _reportRepo.Create(newReport);
                    _pendingReports.Dequeue();
                    await _context.Clients.All.ReceiveNotification($"State has changed, finished {newReport.Name}");                    
                } 
            }
        }
        

        public async Task Add(List<Brand> brands, string reportName)
        {
            _pendingReports.Enqueue(new PendingReport { Brands = brands, ReportName = reportName });
            await _context.Clients.All.ReceiveNotification($"State has changed, added {reportName}");
        }

        public Queue<PendingReport> GetPendingReports()
        {
            return _pendingReports;
        }

        public void GetScopedServices()
        {
            IServiceScope scope = _serviceProvider.CreateScope();
            _reportRepo = scope.ServiceProvider.GetRequiredService<IReportRepo>() ?? throw new Exception("Unable to get scoped service IReportService ");
        }    
    }
}