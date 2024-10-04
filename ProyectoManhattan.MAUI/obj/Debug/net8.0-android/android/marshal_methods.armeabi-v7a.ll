; ModuleID = 'marshal_methods.armeabi-v7a.ll'
source_filename = "marshal_methods.armeabi-v7a.ll"
target datalayout = "e-m:e-p:32:32-Fi8-i64:64-v128:64:128-a:0:32-n32-S64"
target triple = "armv7-unknown-linux-android21"

%struct.MarshalMethodName = type {
	i64, ; uint64_t id
	ptr ; char* name
}

%struct.MarshalMethodsManagedClass = type {
	i32, ; uint32_t token
	ptr ; MonoClass klass
}

@assembly_image_cache = dso_local local_unnamed_addr global [375 x ptr] zeroinitializer, align 4

; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = dso_local local_unnamed_addr constant [744 x i32] [
	i32 2616222, ; 0: System.Net.NetworkInformation.dll => 0x27eb9e => 68
	i32 10166715, ; 1: System.Net.NameResolution.dll => 0x9b21bb => 67
	i32 15721112, ; 2: System.Runtime.Intrinsics.dll => 0xefe298 => 108
	i32 26230656, ; 3: Microsoft.Extensions.DependencyModel => 0x1903f80 => 223
	i32 32687329, ; 4: Xamarin.AndroidX.Lifecycle.Runtime => 0x1f2c4e1 => 292
	i32 34715100, ; 5: Xamarin.Google.Guava.ListenableFuture.dll => 0x211b5dc => 326
	i32 34839235, ; 6: System.IO.FileSystem.DriveInfo => 0x2139ac3 => 48
	i32 39109920, ; 7: Newtonsoft.Json.dll => 0x254c520 => 248
	i32 39485524, ; 8: System.Net.WebSockets.dll => 0x25a8054 => 80
	i32 42639949, ; 9: System.Threading.Thread => 0x28aa24d => 145
	i32 60129738, ; 10: WebDriver.dll => 0x39581ca => 249
	i32 66541672, ; 11: System.Diagnostics.StackTrace => 0x3f75868 => 30
	i32 67008169, ; 12: zh-Hant\Microsoft.Maui.Controls.resources => 0x3fe76a9 => 367
	i32 68219467, ; 13: System.Security.Cryptography.Primitives => 0x410f24b => 124
	i32 72070932, ; 14: Microsoft.Maui.Graphics.dll => 0x44bb714 => 245
	i32 82292897, ; 15: System.Runtime.CompilerServices.VisualC.dll => 0x4e7b0a1 => 102
	i32 98325684, ; 16: Microsoft.Extensions.Diagnostics.Abstractions => 0x5dc54b4 => 224
	i32 101534019, ; 17: Xamarin.AndroidX.SlidingPaneLayout => 0x60d4943 => 310
	i32 117431740, ; 18: System.Runtime.InteropServices => 0x6ffddbc => 107
	i32 120558881, ; 19: Xamarin.AndroidX.SlidingPaneLayout.dll => 0x72f9521 => 310
	i32 122350210, ; 20: System.Threading.Channels.dll => 0x74aea82 => 139
	i32 134690465, ; 21: Xamarin.Kotlin.StdLib.Jdk7.dll => 0x80736a1 => 330
	i32 142721839, ; 22: System.Net.WebHeaderCollection => 0x881c32f => 77
	i32 149972175, ; 23: System.Security.Cryptography.Primitives.dll => 0x8f064cf => 124
	i32 159306688, ; 24: System.ComponentModel.Annotations => 0x97ed3c0 => 13
	i32 165246403, ; 25: Xamarin.AndroidX.Collection.dll => 0x9d975c3 => 266
	i32 176265551, ; 26: System.ServiceProcess => 0xa81994f => 132
	i32 176714968, ; 27: Microsoft.AspNetCore.WebUtilities.dll => 0xa8874d8 => 210
	i32 182336117, ; 28: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0xade3a75 => 312
	i32 184328833, ; 29: System.ValueTuple.dll => 0xafca281 => 151
	i32 195452805, ; 30: vi/Microsoft.Maui.Controls.resources.dll => 0xba65f85 => 364
	i32 199333315, ; 31: zh-HK/Microsoft.Maui.Controls.resources.dll => 0xbe195c3 => 365
	i32 205061960, ; 32: System.ComponentModel => 0xc38ff48 => 18
	i32 209399409, ; 33: Xamarin.AndroidX.Browser.dll => 0xc7b2e71 => 264
	i32 220171995, ; 34: System.Diagnostics.Debug => 0xd1f8edb => 26
	i32 230216969, ; 35: Xamarin.AndroidX.Legacy.Support.Core.Utils.dll => 0xdb8d509 => 286
	i32 230752869, ; 36: Microsoft.CSharp.dll => 0xdc10265 => 1
	i32 231409092, ; 37: System.Linq.Parallel => 0xdcb05c4 => 59
	i32 231814094, ; 38: System.Globalization => 0xdd133ce => 42
	i32 246610117, ; 39: System.Reflection.Emit.Lightweight => 0xeb2f8c5 => 91
	i32 254259026, ; 40: Microsoft.AspNetCore.Components.dll => 0xf27af52 => 193
	i32 261689757, ; 41: Xamarin.AndroidX.ConstraintLayout.dll => 0xf99119d => 269
	i32 276479776, ; 42: System.Threading.Timer.dll => 0x107abf20 => 147
	i32 278686392, ; 43: Xamarin.AndroidX.Lifecycle.LiveData.dll => 0x109c6ab8 => 288
	i32 280482487, ; 44: Xamarin.AndroidX.Interpolator => 0x10b7d2b7 => 285
	i32 280992041, ; 45: cs/Microsoft.Maui.Controls.resources.dll => 0x10bf9929 => 336
	i32 291076382, ; 46: System.IO.Pipes.AccessControl.dll => 0x1159791e => 54
	i32 298918909, ; 47: System.Net.Ping.dll => 0x11d123fd => 69
	i32 300686228, ; 48: Microsoft.AspNetCore.Authentication.Abstractions.dll => 0x11ec1b94 => 189
	i32 317674968, ; 49: vi\Microsoft.Maui.Controls.resources => 0x12ef55d8 => 364
	i32 318968648, ; 50: Xamarin.AndroidX.Activity.dll => 0x13031348 => 255
	i32 321597661, ; 51: System.Numerics => 0x132b30dd => 83
	i32 336156722, ; 52: ja/Microsoft.Maui.Controls.resources.dll => 0x14095832 => 349
	i32 342366114, ; 53: Xamarin.AndroidX.Lifecycle.Common => 0x146817a2 => 287
	i32 344827588, ; 54: Microsoft.AspNetCore.ResponseCaching.Abstractions => 0x148da6c4 => 207
	i32 356389973, ; 55: it/Microsoft.Maui.Controls.resources.dll => 0x153e1455 => 348
	i32 360082299, ; 56: System.ServiceModel.Web => 0x15766b7b => 131
	i32 367780167, ; 57: System.IO.Pipes => 0x15ebe147 => 55
	i32 374914964, ; 58: System.Transactions.Local => 0x1658bf94 => 149
	i32 375677976, ; 59: System.Net.ServicePoint.dll => 0x16646418 => 74
	i32 379916513, ; 60: System.Threading.Thread.dll => 0x16a510e1 => 145
	i32 384051609, ; 61: Microsoft.AspNetCore.Routing.dll => 0x16e42999 => 208
	i32 385762202, ; 62: System.Memory.dll => 0x16fe439a => 62
	i32 392610295, ; 63: System.Threading.ThreadPool.dll => 0x1766c1f7 => 146
	i32 395744057, ; 64: _Microsoft.Android.Resource.Designer => 0x17969339 => 371
	i32 403441872, ; 65: WindowsBase => 0x180c08d0 => 165
	i32 435591531, ; 66: sv/Microsoft.Maui.Controls.resources.dll => 0x19f6996b => 360
	i32 441335492, ; 67: Xamarin.AndroidX.ConstraintLayout.Core => 0x1a4e3ec4 => 270
	i32 442565967, ; 68: System.Collections => 0x1a61054f => 12
	i32 450948140, ; 69: Xamarin.AndroidX.Fragment.dll => 0x1ae0ec2c => 283
	i32 451504562, ; 70: System.Security.Cryptography.X509Certificates => 0x1ae969b2 => 125
	i32 456227837, ; 71: System.Web.HttpUtility.dll => 0x1b317bfd => 152
	i32 459347974, ; 72: System.Runtime.Serialization.Primitives.dll => 0x1b611806 => 113
	i32 465846621, ; 73: mscorlib => 0x1bc4415d => 166
	i32 469710990, ; 74: System.dll => 0x1bff388e => 164
	i32 476646585, ; 75: Xamarin.AndroidX.Interpolator.dll => 0x1c690cb9 => 285
	i32 486930444, ; 76: Xamarin.AndroidX.LocalBroadcastManager.dll => 0x1d05f80c => 298
	i32 490002678, ; 77: Microsoft.AspNetCore.Hosting.Server.Abstractions.dll => 0x1d34d8f6 => 199
	i32 498788369, ; 78: System.ObjectModel => 0x1dbae811 => 84
	i32 500358224, ; 79: id/Microsoft.Maui.Controls.resources.dll => 0x1dd2dc50 => 347
	i32 503918385, ; 80: fi/Microsoft.Maui.Controls.resources.dll => 0x1e092f31 => 341
	i32 513247710, ; 81: Microsoft.Extensions.Primitives.dll => 0x1e9789de => 238
	i32 526420162, ; 82: System.Transactions.dll => 0x1f6088c2 => 150
	i32 527452488, ; 83: Xamarin.Kotlin.StdLib.Jdk7 => 0x1f704948 => 330
	i32 530272170, ; 84: System.Linq.Queryable => 0x1f9b4faa => 60
	i32 539058512, ; 85: Microsoft.Extensions.Logging => 0x20216150 => 233
	i32 540030774, ; 86: System.IO.FileSystem.dll => 0x20303736 => 51
	i32 545304856, ; 87: System.Runtime.Extensions => 0x2080b118 => 103
	i32 546455878, ; 88: System.Runtime.Serialization.Xml => 0x20924146 => 114
	i32 549171840, ; 89: System.Globalization.Calendars => 0x20bbb280 => 40
	i32 557405415, ; 90: Jsr305Binding => 0x213954e7 => 323
	i32 569601784, ; 91: Xamarin.AndroidX.Window.Extensions.Core.Core => 0x21f36ef8 => 321
	i32 571435654, ; 92: Microsoft.Extensions.FileProviders.Embedded.dll => 0x220f6a86 => 227
	i32 577335427, ; 93: System.Security.Cryptography.Cng => 0x22697083 => 120
	i32 592146354, ; 94: pt-BR/Microsoft.Maui.Controls.resources.dll => 0x234b6fb2 => 355
	i32 601371474, ; 95: System.IO.IsolatedStorage.dll => 0x23d83352 => 52
	i32 605376203, ; 96: System.IO.Compression.FileSystem => 0x24154ecb => 44
	i32 606421715, ; 97: itext.layout => 0x242542d3 => 180
	i32 613668793, ; 98: System.Security.Cryptography.Algorithms => 0x2493d7b9 => 119
	i32 627609679, ; 99: Xamarin.AndroidX.CustomView => 0x2568904f => 275
	i32 627931235, ; 100: nl\Microsoft.Maui.Controls.resources => 0x256d7863 => 353
	i32 639843206, ; 101: Xamarin.AndroidX.Emoji2.ViewsHelper.dll => 0x26233b86 => 281
	i32 643868501, ; 102: System.Net => 0x2660a755 => 81
	i32 662205335, ; 103: System.Text.Encodings.Web.dll => 0x27787397 => 136
	i32 663517072, ; 104: Xamarin.AndroidX.VersionedParcelable => 0x278c7790 => 317
	i32 666292255, ; 105: Xamarin.AndroidX.Arch.Core.Common.dll => 0x27b6d01f => 262
	i32 672442732, ; 106: System.Collections.Concurrent => 0x2814a96c => 8
	i32 683518922, ; 107: System.Net.Security => 0x28bdabca => 73
	i32 688181140, ; 108: ca/Microsoft.Maui.Controls.resources.dll => 0x2904cf94 => 335
	i32 690569205, ; 109: System.Xml.Linq.dll => 0x29293ff5 => 155
	i32 691348768, ; 110: Xamarin.KotlinX.Coroutines.Android.dll => 0x29352520 => 332
	i32 693804605, ; 111: System.Windows => 0x295a9e3d => 154
	i32 699345723, ; 112: System.Reflection.Emit => 0x29af2b3b => 92
	i32 700284507, ; 113: Xamarin.Jetbrains.Annotations => 0x29bd7e5b => 327
	i32 700358131, ; 114: System.IO.Compression.ZipFile => 0x29be9df3 => 45
	i32 706645707, ; 115: ko/Microsoft.Maui.Controls.resources.dll => 0x2a1e8ecb => 350
	i32 709557578, ; 116: de/Microsoft.Maui.Controls.resources.dll => 0x2a4afd4a => 338
	i32 720511267, ; 117: Xamarin.Kotlin.StdLib.Jdk8 => 0x2af22123 => 331
	i32 722857257, ; 118: System.Runtime.Loader.dll => 0x2b15ed29 => 109
	i32 724146010, ; 119: Microsoft.AspNetCore.Authorization.Policy.dll => 0x2b29975a => 192
	i32 735137430, ; 120: System.Security.SecureString.dll => 0x2bd14e96 => 129
	i32 752232764, ; 121: System.Diagnostics.Contracts.dll => 0x2cd6293c => 25
	i32 755313932, ; 122: Xamarin.Android.Glide.Annotations.dll => 0x2d052d0c => 252
	i32 759454413, ; 123: System.Net.Requests => 0x2d445acd => 72
	i32 762598435, ; 124: System.IO.Pipes.dll => 0x2d745423 => 55
	i32 775507847, ; 125: System.IO.Compression => 0x2e394f87 => 46
	i32 777317022, ; 126: sk\Microsoft.Maui.Controls.resources => 0x2e54ea9e => 359
	i32 789151979, ; 127: Microsoft.Extensions.Options => 0x2f0980eb => 237
	i32 790371945, ; 128: Xamarin.AndroidX.CustomView.PoolingContainer.dll => 0x2f1c1e69 => 276
	i32 804008546, ; 129: Microsoft.AspNetCore.Components.WebView.Maui => 0x2fec3262 => 197
	i32 804715423, ; 130: System.Data.Common => 0x2ff6fb9f => 22
	i32 807930345, ; 131: Xamarin.AndroidX.Lifecycle.LiveData.Core.Ktx.dll => 0x302809e9 => 290
	i32 823281589, ; 132: System.Private.Uri.dll => 0x311247b5 => 86
	i32 830298997, ; 133: System.IO.Compression.Brotli => 0x317d5b75 => 43
	i32 832635846, ; 134: System.Xml.XPath.dll => 0x31a103c6 => 160
	i32 834051424, ; 135: System.Net.Quic => 0x31b69d60 => 71
	i32 843511501, ; 136: Xamarin.AndroidX.Print => 0x3246f6cd => 303
	i32 873119928, ; 137: Microsoft.VisualBasic => 0x340ac0b8 => 3
	i32 877678880, ; 138: System.Globalization.dll => 0x34505120 => 42
	i32 878954865, ; 139: System.Net.Http.Json => 0x3463c971 => 63
	i32 904024072, ; 140: System.ComponentModel.Primitives.dll => 0x35e25008 => 16
	i32 904257677, ; 141: ProyectoManhattan.BlazorComponents.dll => 0x35e5e08d => 369
	i32 911108515, ; 142: System.IO.MemoryMappedFiles.dll => 0x364e69a3 => 53
	i32 917108320, ; 143: itext.io => 0x36a9f660 => 178
	i32 926902833, ; 144: tr/Microsoft.Maui.Controls.resources.dll => 0x373f6a31 => 362
	i32 928116545, ; 145: Xamarin.Google.Guava.ListenableFuture => 0x3751ef41 => 326
	i32 952186615, ; 146: System.Runtime.InteropServices.JavaScript.dll => 0x38c136f7 => 105
	i32 955402788, ; 147: Newtonsoft.Json => 0x38f24a24 => 248
	i32 956575887, ; 148: Xamarin.Kotlin.StdLib.Jdk8.dll => 0x3904308f => 331
	i32 966729478, ; 149: Xamarin.Google.Crypto.Tink.Android => 0x399f1f06 => 324
	i32 967690846, ; 150: Xamarin.AndroidX.Lifecycle.Common.dll => 0x39adca5e => 287
	i32 971744099, ; 151: itext.barcodes.dll => 0x39eba363 => 175
	i32 975236339, ; 152: System.Diagnostics.Tracing => 0x3a20ecf3 => 34
	i32 975874589, ; 153: System.Xml.XDocument => 0x3a2aaa1d => 158
	i32 986514023, ; 154: System.Private.DataContractSerialization.dll => 0x3acd0267 => 85
	i32 987214855, ; 155: System.Diagnostics.Tools => 0x3ad7b407 => 32
	i32 992768348, ; 156: System.Collections.dll => 0x3b2c715c => 12
	i32 994442037, ; 157: System.IO.FileSystem => 0x3b45fb35 => 51
	i32 999186168, ; 158: Microsoft.Extensions.FileSystemGlobbing.dll => 0x3b8e5ef8 => 229
	i32 1001831731, ; 159: System.IO.UnmanagedMemoryStream.dll => 0x3bb6bd33 => 56
	i32 1003095741, ; 160: ProyectoManhattan.MAUI => 0x3bca06bd => 0
	i32 1012816738, ; 161: Xamarin.AndroidX.SavedState.dll => 0x3c5e5b62 => 307
	i32 1019214401, ; 162: System.Drawing => 0x3cbffa41 => 36
	i32 1028951442, ; 163: Microsoft.Extensions.DependencyInjection.Abstractions => 0x3d548d92 => 222
	i32 1029334545, ; 164: da/Microsoft.Maui.Controls.resources.dll => 0x3d5a6611 => 337
	i32 1031528504, ; 165: Xamarin.Google.ErrorProne.Annotations.dll => 0x3d7be038 => 325
	i32 1035644815, ; 166: Xamarin.AndroidX.AppCompat => 0x3dbaaf8f => 260
	i32 1036536393, ; 167: System.Drawing.Primitives.dll => 0x3dc84a49 => 35
	i32 1044663988, ; 168: System.Linq.Expressions.dll => 0x3e444eb4 => 58
	i32 1048992957, ; 169: Microsoft.Extensions.Diagnostics.Abstractions.dll => 0x3e865cbd => 224
	i32 1052210849, ; 170: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x3eb776a1 => 294
	i32 1067306892, ; 171: GoogleGson => 0x3f9dcf8c => 174
	i32 1067609627, ; 172: itext.forms => 0x3fa26e1b => 177
	i32 1074246011, ; 173: itext.kernel.dll => 0x4007b17b => 179
	i32 1082531809, ; 174: itext.bouncy-castle-adapter => 0x40861fe1 => 186
	i32 1082857460, ; 175: System.ComponentModel.TypeConverter => 0x408b17f4 => 17
	i32 1084122840, ; 176: Xamarin.Kotlin.StdLib => 0x409e66d8 => 328
	i32 1098259244, ; 177: System => 0x41761b2c => 164
	i32 1099692271, ; 178: Microsoft.DotNet.PlatformAbstractions => 0x418bf8ef => 211
	i32 1106973742, ; 179: Microsoft.Extensions.Configuration.FileExtensions.dll => 0x41fb142e => 219
	i32 1110309514, ; 180: Microsoft.Extensions.Hosting.Abstractions => 0x422dfa8a => 230
	i32 1112354281, ; 181: Microsoft.AspNetCore.Authentication.Abstractions => 0x424d2de9 => 189
	i32 1118262833, ; 182: ko\Microsoft.Maui.Controls.resources => 0x42a75631 => 350
	i32 1121599056, ; 183: Xamarin.AndroidX.Lifecycle.Runtime.Ktx.dll => 0x42da3e50 => 293
	i32 1127624469, ; 184: Microsoft.Extensions.Logging.Debug => 0x43362f15 => 235
	i32 1149092582, ; 185: Xamarin.AndroidX.Window => 0x447dc2e6 => 320
	i32 1157931901, ; 186: Microsoft.EntityFrameworkCore.Abstractions => 0x4504a37d => 213
	i32 1168523401, ; 187: pt\Microsoft.Maui.Controls.resources => 0x45a64089 => 356
	i32 1170634674, ; 188: System.Web.dll => 0x45c677b2 => 153
	i32 1173126369, ; 189: Microsoft.Extensions.FileProviders.Abstractions.dll => 0x45ec7ce1 => 225
	i32 1175144683, ; 190: Xamarin.AndroidX.VectorDrawable.Animated => 0x460b48eb => 316
	i32 1178241025, ; 191: Xamarin.AndroidX.Navigation.Runtime.dll => 0x463a8801 => 301
	i32 1202000627, ; 192: Microsoft.EntityFrameworkCore.Abstractions.dll => 0x47a512f3 => 213
	i32 1203215381, ; 193: pl/Microsoft.Maui.Controls.resources.dll => 0x47b79c15 => 354
	i32 1204270330, ; 194: Xamarin.AndroidX.Arch.Core.Common => 0x47c7b4fa => 262
	i32 1204575371, ; 195: Microsoft.Extensions.Caching.Memory.dll => 0x47cc5c8b => 215
	i32 1208641965, ; 196: System.Diagnostics.Process => 0x480a69ad => 29
	i32 1219128291, ; 197: System.IO.IsolatedStorage => 0x48aa6be3 => 52
	i32 1220193633, ; 198: Microsoft.Net.Http.Headers => 0x48baad61 => 246
	i32 1222247595, ; 199: itext.pdfua.dll => 0x48da04ab => 182
	i32 1234928153, ; 200: nb/Microsoft.Maui.Controls.resources.dll => 0x499b8219 => 352
	i32 1236289705, ; 201: Microsoft.AspNetCore.Hosting.Server.Abstractions => 0x49b048a9 => 199
	i32 1243150071, ; 202: Xamarin.AndroidX.Window.Extensions.Core.Core.dll => 0x4a18f6f7 => 321
	i32 1245460359, ; 203: itext.svg => 0x4a3c3787 => 185
	i32 1250430400, ; 204: itext.commons.dll => 0x4a880dc0 => 187
	i32 1253011324, ; 205: Microsoft.Win32.Registry => 0x4aaf6f7c => 5
	i32 1260983243, ; 206: cs\Microsoft.Maui.Controls.resources => 0x4b2913cb => 336
	i32 1264511973, ; 207: Xamarin.AndroidX.Startup.StartupRuntime.dll => 0x4b5eebe5 => 311
	i32 1267360935, ; 208: Xamarin.AndroidX.VectorDrawable => 0x4b8a64a7 => 315
	i32 1267908789, ; 209: Microsoft.AspNetCore.Routing => 0x4b92c0b5 => 208
	i32 1273260888, ; 210: Xamarin.AndroidX.Collection.Ktx => 0x4be46b58 => 267
	i32 1275534314, ; 211: Xamarin.KotlinX.Coroutines.Android => 0x4c071bea => 332
	i32 1278448581, ; 212: Xamarin.AndroidX.Annotation.Jvm => 0x4c3393c5 => 259
	i32 1278779541, ; 213: itext.pdfa.dll => 0x4c38a095 => 181
	i32 1293217323, ; 214: Xamarin.AndroidX.DrawerLayout.dll => 0x4d14ee2b => 278
	i32 1309188875, ; 215: System.Private.DataContractSerialization => 0x4e08a30b => 85
	i32 1322716291, ; 216: Xamarin.AndroidX.Window.dll => 0x4ed70c83 => 320
	i32 1324164729, ; 217: System.Linq => 0x4eed2679 => 61
	i32 1335329327, ; 218: System.Runtime.Serialization.Json.dll => 0x4f97822f => 112
	i32 1364015309, ; 219: System.IO => 0x514d38cd => 57
	i32 1373134921, ; 220: zh-Hans\Microsoft.Maui.Controls.resources => 0x51d86049 => 366
	i32 1376866003, ; 221: Xamarin.AndroidX.SavedState => 0x52114ed3 => 307
	i32 1379779777, ; 222: System.Resources.ResourceManager => 0x523dc4c1 => 99
	i32 1402170036, ; 223: System.Configuration.dll => 0x53936ab4 => 19
	i32 1406073936, ; 224: Xamarin.AndroidX.CoordinatorLayout => 0x53cefc50 => 271
	i32 1408764838, ; 225: System.Runtime.Serialization.Formatters.dll => 0x53f80ba6 => 111
	i32 1411638395, ; 226: System.Runtime.CompilerServices.Unsafe => 0x5423e47b => 101
	i32 1422545099, ; 227: System.Runtime.CompilerServices.VisualC => 0x54ca50cb => 102
	i32 1430672901, ; 228: ar\Microsoft.Maui.Controls.resources => 0x55465605 => 334
	i32 1434145427, ; 229: System.Runtime.Handles => 0x557b5293 => 104
	i32 1435222561, ; 230: Xamarin.Google.Crypto.Tink.Android.dll => 0x558bc221 => 324
	i32 1439761251, ; 231: System.Net.Quic.dll => 0x55d10363 => 71
	i32 1452070440, ; 232: System.Formats.Asn1.dll => 0x568cd628 => 38
	i32 1453312822, ; 233: System.Diagnostics.Tools.dll => 0x569fcb36 => 32
	i32 1454105418, ; 234: Microsoft.Extensions.FileProviders.Composite => 0x56abe34a => 226
	i32 1457743152, ; 235: System.Runtime.Extensions.dll => 0x56e36530 => 103
	i32 1458022317, ; 236: System.Net.Security.dll => 0x56e7a7ad => 73
	i32 1461004990, ; 237: es\Microsoft.Maui.Controls.resources => 0x57152abe => 340
	i32 1461234159, ; 238: System.Collections.Immutable.dll => 0x5718a9ef => 9
	i32 1461719063, ; 239: System.Security.Cryptography.OpenSsl => 0x57201017 => 123
	i32 1462112819, ; 240: System.IO.Compression.dll => 0x57261233 => 46
	i32 1469204771, ; 241: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x57924923 => 261
	i32 1470490898, ; 242: Microsoft.Extensions.Primitives => 0x57a5e912 => 238
	i32 1479771757, ; 243: System.Collections.Immutable => 0x5833866d => 9
	i32 1480492111, ; 244: System.IO.Compression.Brotli.dll => 0x583e844f => 43
	i32 1487239319, ; 245: Microsoft.Win32.Primitives => 0x58a57897 => 4
	i32 1488664300, ; 246: itext.bouncy-castle-connector.dll => 0x58bb36ec => 176
	i32 1490025113, ; 247: Xamarin.AndroidX.SavedState.SavedState.Ktx.dll => 0x58cffa99 => 308
	i32 1493001747, ; 248: hi/Microsoft.Maui.Controls.resources.dll => 0x58fd6613 => 344
	i32 1514721132, ; 249: el/Microsoft.Maui.Controls.resources.dll => 0x5a48cf6c => 339
	i32 1521091094, ; 250: Microsoft.Extensions.FileSystemGlobbing => 0x5aaa0216 => 229
	i32 1536373174, ; 251: System.Diagnostics.TextWriterTraceListener => 0x5b9331b6 => 31
	i32 1543031311, ; 252: System.Text.RegularExpressions.dll => 0x5bf8ca0f => 138
	i32 1543355203, ; 253: System.Reflection.Emit.dll => 0x5bfdbb43 => 92
	i32 1546581739, ; 254: Microsoft.AspNetCore.Components.WebView.Maui.dll => 0x5c2ef6eb => 197
	i32 1550322496, ; 255: System.Reflection.Extensions.dll => 0x5c680b40 => 93
	i32 1551623176, ; 256: sk/Microsoft.Maui.Controls.resources.dll => 0x5c7be408 => 359
	i32 1565862583, ; 257: System.IO.FileSystem.Primitives => 0x5d552ab7 => 49
	i32 1566207040, ; 258: System.Threading.Tasks.Dataflow.dll => 0x5d5a6c40 => 141
	i32 1573704789, ; 259: System.Runtime.Serialization.Json => 0x5dccd455 => 112
	i32 1580037396, ; 260: System.Threading.Overlapped => 0x5e2d7514 => 140
	i32 1582372066, ; 261: Xamarin.AndroidX.DocumentFile.dll => 0x5e5114e2 => 277
	i32 1592978981, ; 262: System.Runtime.Serialization.dll => 0x5ef2ee25 => 115
	i32 1597949149, ; 263: Xamarin.Google.ErrorProne.Annotations => 0x5f3ec4dd => 325
	i32 1601112923, ; 264: System.Xml.Serialization => 0x5f6f0b5b => 157
	i32 1604827217, ; 265: System.Net.WebClient => 0x5fa7b851 => 76
	i32 1618516317, ; 266: System.Net.WebSockets.Client.dll => 0x6078995d => 79
	i32 1622152042, ; 267: Xamarin.AndroidX.Loader.dll => 0x60b0136a => 297
	i32 1622358360, ; 268: System.Dynamic.Runtime => 0x60b33958 => 37
	i32 1624863272, ; 269: Xamarin.AndroidX.ViewPager2 => 0x60d97228 => 319
	i32 1632842087, ; 270: Microsoft.Extensions.Configuration.Json => 0x61533167 => 220
	i32 1635184631, ; 271: Xamarin.AndroidX.Emoji2.ViewsHelper => 0x6176eff7 => 281
	i32 1636350590, ; 272: Xamarin.AndroidX.CursorAdapter => 0x6188ba7e => 274
	i32 1639515021, ; 273: System.Net.Http.dll => 0x61b9038d => 64
	i32 1639986890, ; 274: System.Text.RegularExpressions => 0x61c036ca => 138
	i32 1641389582, ; 275: System.ComponentModel.EventBasedAsync.dll => 0x61d59e0e => 15
	i32 1654881142, ; 276: Microsoft.AspNetCore.Components.WebView => 0x62a37b76 => 196
	i32 1657153582, ; 277: System.Runtime => 0x62c6282e => 116
	i32 1658241508, ; 278: Xamarin.AndroidX.Tracing.Tracing.dll => 0x62d6c1e4 => 313
	i32 1658251792, ; 279: Xamarin.Google.Android.Material.dll => 0x62d6ea10 => 322
	i32 1670060433, ; 280: Xamarin.AndroidX.ConstraintLayout => 0x638b1991 => 269
	i32 1672083785, ; 281: itext.pdfa => 0x63a9f949 => 181
	i32 1675553242, ; 282: System.IO.FileSystem.DriveInfo.dll => 0x63dee9da => 48
	i32 1677501392, ; 283: System.Net.Primitives.dll => 0x63fca3d0 => 70
	i32 1678508291, ; 284: System.Net.WebSockets => 0x640c0103 => 80
	i32 1679769178, ; 285: System.Security.Cryptography => 0x641f3e5a => 126
	i32 1689493916, ; 286: Microsoft.EntityFrameworkCore.dll => 0x64b3a19c => 212
	i32 1691477237, ; 287: System.Reflection.Metadata => 0x64d1e4f5 => 94
	i32 1696967625, ; 288: System.Security.Cryptography.Csp => 0x6525abc9 => 121
	i32 1697259279, ; 289: ProyectoManhattan.Domain.dll => 0x652a1f0f => 370
	i32 1698840827, ; 290: Xamarin.Kotlin.StdLib.Common => 0x654240fb => 329
	i32 1701541528, ; 291: System.Diagnostics.Debug.dll => 0x656b7698 => 26
	i32 1720223769, ; 292: Xamarin.AndroidX.Lifecycle.LiveData.Core.Ktx => 0x66888819 => 290
	i32 1726116996, ; 293: System.Reflection.dll => 0x66e27484 => 97
	i32 1728033016, ; 294: System.Diagnostics.FileVersionInfo.dll => 0x66ffb0f8 => 28
	i32 1729485958, ; 295: Xamarin.AndroidX.CardView.dll => 0x6715dc86 => 265
	i32 1736233607, ; 296: ro/Microsoft.Maui.Controls.resources.dll => 0x677cd287 => 357
	i32 1743415430, ; 297: ca\Microsoft.Maui.Controls.resources => 0x67ea6886 => 335
	i32 1744735666, ; 298: System.Transactions.Local.dll => 0x67fe8db2 => 149
	i32 1746115085, ; 299: System.IO.Pipelines.dll => 0x68139a0d => 250
	i32 1746316138, ; 300: Mono.Android.Export => 0x6816ab6a => 169
	i32 1750313021, ; 301: Microsoft.Win32.Primitives.dll => 0x6853a83d => 4
	i32 1758240030, ; 302: System.Resources.Reader.dll => 0x68cc9d1e => 98
	i32 1760259689, ; 303: Microsoft.AspNetCore.Components.Web.dll => 0x68eb6e69 => 195
	i32 1763938596, ; 304: System.Diagnostics.TraceSource.dll => 0x69239124 => 33
	i32 1765942094, ; 305: System.Reflection.Extensions => 0x6942234e => 93
	i32 1766324549, ; 306: Xamarin.AndroidX.SwipeRefreshLayout => 0x6947f945 => 312
	i32 1770582343, ; 307: Microsoft.Extensions.Logging.dll => 0x6988f147 => 233
	i32 1776026572, ; 308: System.Core.dll => 0x69dc03cc => 21
	i32 1777075843, ; 309: System.Globalization.Extensions.dll => 0x69ec0683 => 41
	i32 1780572499, ; 310: Mono.Android.Runtime.dll => 0x6a216153 => 170
	i32 1782862114, ; 311: ms\Microsoft.Maui.Controls.resources => 0x6a445122 => 351
	i32 1788241197, ; 312: Xamarin.AndroidX.Fragment => 0x6a96652d => 283
	i32 1793755602, ; 313: he\Microsoft.Maui.Controls.resources => 0x6aea89d2 => 343
	i32 1808609942, ; 314: Xamarin.AndroidX.Loader => 0x6bcd3296 => 297
	i32 1813058853, ; 315: Xamarin.Kotlin.StdLib.dll => 0x6c111525 => 328
	i32 1813201214, ; 316: Xamarin.Google.Android.Material => 0x6c13413e => 322
	i32 1818569960, ; 317: Xamarin.AndroidX.Navigation.UI.dll => 0x6c652ce8 => 302
	i32 1818787751, ; 318: Microsoft.VisualBasic.Core => 0x6c687fa7 => 2
	i32 1819327070, ; 319: Microsoft.AspNetCore.Http.Features.dll => 0x6c70ba5e => 203
	i32 1824175904, ; 320: System.Text.Encoding.Extensions => 0x6cbab720 => 134
	i32 1824722060, ; 321: System.Runtime.Serialization.Formatters => 0x6cc30c8c => 111
	i32 1828688058, ; 322: Microsoft.Extensions.Logging.Abstractions.dll => 0x6cff90ba => 234
	i32 1842015223, ; 323: uk/Microsoft.Maui.Controls.resources.dll => 0x6dcaebf7 => 363
	i32 1847515442, ; 324: Xamarin.Android.Glide.Annotations => 0x6e1ed932 => 252
	i32 1853025655, ; 325: sv\Microsoft.Maui.Controls.resources => 0x6e72ed77 => 360
	i32 1858542181, ; 326: System.Linq.Expressions => 0x6ec71a65 => 58
	i32 1870277092, ; 327: System.Reflection.Primitives => 0x6f7a29e4 => 95
	i32 1875935024, ; 328: fr\Microsoft.Maui.Controls.resources => 0x6fd07f30 => 342
	i32 1879696579, ; 329: System.Formats.Tar.dll => 0x7009e4c3 => 39
	i32 1885316902, ; 330: Xamarin.AndroidX.Arch.Core.Runtime.dll => 0x705fa726 => 263
	i32 1888955245, ; 331: System.Diagnostics.Contracts => 0x70972b6d => 25
	i32 1889954781, ; 332: System.Reflection.Metadata.dll => 0x70a66bdd => 94
	i32 1894524299, ; 333: Microsoft.DotNet.PlatformAbstractions.dll => 0x70ec258b => 211
	i32 1898237753, ; 334: System.Reflection.DispatchProxy => 0x7124cf39 => 89
	i32 1900610850, ; 335: System.Resources.ResourceManager.dll => 0x71490522 => 99
	i32 1910275211, ; 336: System.Collections.NonGeneric.dll => 0x71dc7c8b => 10
	i32 1928288591, ; 337: Microsoft.AspNetCore.Http.Abstractions => 0x72ef594f => 201
	i32 1939592360, ; 338: System.Private.Xml.Linq => 0x739bd4a8 => 87
	i32 1956758971, ; 339: System.Resources.Writer => 0x74a1c5bb => 100
	i32 1961813231, ; 340: Xamarin.AndroidX.Security.SecurityCrypto.dll => 0x74eee4ef => 309
	i32 1968388702, ; 341: Microsoft.Extensions.Configuration.dll => 0x75533a5e => 216
	i32 1983156543, ; 342: Xamarin.Kotlin.StdLib.Common.dll => 0x7634913f => 329
	i32 1985761444, ; 343: Xamarin.Android.Glide.GifDecoder => 0x765c50a4 => 254
	i32 2003115576, ; 344: el\Microsoft.Maui.Controls.resources => 0x77651e38 => 339
	i32 2011961780, ; 345: System.Buffers.dll => 0x77ec19b4 => 7
	i32 2019465201, ; 346: Xamarin.AndroidX.Lifecycle.ViewModel => 0x785e97f1 => 294
	i32 2025202353, ; 347: ar/Microsoft.Maui.Controls.resources.dll => 0x78b622b1 => 334
	i32 2031763787, ; 348: Xamarin.Android.Glide => 0x791a414b => 251
	i32 2045470958, ; 349: System.Private.Xml => 0x79eb68ee => 88
	i32 2045845235, ; 350: itext.pdfua => 0x79f11ef3 => 182
	i32 2048278909, ; 351: Microsoft.Extensions.Configuration.Binder.dll => 0x7a16417d => 218
	i32 2055257422, ; 352: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x7a80bd4e => 289
	i32 2060060697, ; 353: System.Windows.dll => 0x7aca0819 => 154
	i32 2066184531, ; 354: de\Microsoft.Maui.Controls.resources => 0x7b277953 => 338
	i32 2070888862, ; 355: System.Diagnostics.TraceSource => 0x7b6f419e => 33
	i32 2072397586, ; 356: Microsoft.Extensions.FileProviders.Physical => 0x7b864712 => 228
	i32 2075706075, ; 357: Microsoft.AspNetCore.Http.Abstractions.dll => 0x7bb8c2db => 201
	i32 2079903147, ; 358: System.Runtime.dll => 0x7bf8cdab => 116
	i32 2090596640, ; 359: System.Numerics.Vectors => 0x7c9bf920 => 82
	i32 2127167465, ; 360: System.Console => 0x7ec9ffe9 => 20
	i32 2142473426, ; 361: System.Collections.Specialized => 0x7fb38cd2 => 11
	i32 2143790110, ; 362: System.Xml.XmlSerializer.dll => 0x7fc7a41e => 162
	i32 2146852085, ; 363: Microsoft.VisualBasic.dll => 0x7ff65cf5 => 3
	i32 2159891885, ; 364: Microsoft.Maui => 0x80bd55ad => 243
	i32 2169148018, ; 365: hu\Microsoft.Maui.Controls.resources => 0x814a9272 => 346
	i32 2181898931, ; 366: Microsoft.Extensions.Options.dll => 0x820d22b3 => 237
	i32 2182738860, ; 367: Microsoft.AspNetCore.Mvc.Core.dll => 0x8219f3ac => 206
	i32 2192057212, ; 368: Microsoft.Extensions.Logging.Abstractions => 0x82a8237c => 234
	i32 2193016926, ; 369: System.ObjectModel.dll => 0x82b6c85e => 84
	i32 2197979891, ; 370: Microsoft.Extensions.DependencyModel.dll => 0x830282f3 => 223
	i32 2201107256, ; 371: Xamarin.KotlinX.Coroutines.Core.Jvm.dll => 0x83323b38 => 333
	i32 2201231467, ; 372: System.Net.Http => 0x8334206b => 64
	i32 2204417087, ; 373: Microsoft.Extensions.ObjectPool => 0x8364bc3f => 236
	i32 2207618523, ; 374: it\Microsoft.Maui.Controls.resources => 0x839595db => 348
	i32 2217644978, ; 375: Xamarin.AndroidX.VectorDrawable.Animated.dll => 0x842e93b2 => 316
	i32 2222056684, ; 376: System.Threading.Tasks.Parallel => 0x8471e4ec => 143
	i32 2242871324, ; 377: Microsoft.AspNetCore.Http.dll => 0x85af801c => 200
	i32 2244775296, ; 378: Xamarin.AndroidX.LocalBroadcastManager => 0x85cc8d80 => 298
	i32 2252106437, ; 379: System.Xml.Serialization.dll => 0x863c6ac5 => 157
	i32 2252897993, ; 380: Microsoft.EntityFrameworkCore => 0x86487ec9 => 212
	i32 2256313426, ; 381: System.Globalization.Extensions => 0x867c9c52 => 41
	i32 2265110946, ; 382: System.Security.AccessControl.dll => 0x8702d9a2 => 117
	i32 2266799131, ; 383: Microsoft.Extensions.Configuration.Abstractions => 0x871c9c1b => 217
	i32 2267999099, ; 384: Xamarin.Android.Glide.DiskLruCache.dll => 0x872eeb7b => 253
	i32 2270573516, ; 385: fr/Microsoft.Maui.Controls.resources.dll => 0x875633cc => 342
	i32 2279755925, ; 386: Xamarin.AndroidX.RecyclerView.dll => 0x87e25095 => 305
	i32 2285293097, ; 387: Microsoft.AspNetCore.Mvc.Abstractions => 0x8836ce29 => 205
	i32 2293034957, ; 388: System.ServiceModel.Web.dll => 0x88acefcd => 131
	i32 2295906218, ; 389: System.Net.Sockets => 0x88d8bfaa => 75
	i32 2298471582, ; 390: System.Net.Mail => 0x88ffe49e => 66
	i32 2303942373, ; 391: nb\Microsoft.Maui.Controls.resources => 0x89535ee5 => 352
	i32 2305521784, ; 392: System.Private.CoreLib.dll => 0x896b7878 => 172
	i32 2315684594, ; 393: Xamarin.AndroidX.Annotation.dll => 0x8a068af2 => 257
	i32 2320631194, ; 394: System.Threading.Tasks.Parallel.dll => 0x8a52059a => 143
	i32 2321784778, ; 395: Microsoft.AspNetCore.Mvc.Abstractions.dll => 0x8a639fca => 205
	i32 2340441535, ; 396: System.Runtime.InteropServices.RuntimeInformation.dll => 0x8b804dbf => 106
	i32 2344264397, ; 397: System.ValueTuple => 0x8bbaa2cd => 151
	i32 2353062107, ; 398: System.Net.Primitives => 0x8c40e0db => 70
	i32 2368005991, ; 399: System.Xml.ReaderWriter.dll => 0x8d24e767 => 156
	i32 2371007202, ; 400: Microsoft.Extensions.Configuration => 0x8d52b2e2 => 216
	i32 2378619854, ; 401: System.Security.Cryptography.Csp.dll => 0x8dc6dbce => 121
	i32 2383496789, ; 402: System.Security.Principal.Windows.dll => 0x8e114655 => 127
	i32 2395872292, ; 403: id\Microsoft.Maui.Controls.resources => 0x8ece1c24 => 347
	i32 2401565422, ; 404: System.Web.HttpUtility => 0x8f24faee => 152
	i32 2403452196, ; 405: Xamarin.AndroidX.Emoji2.dll => 0x8f41c524 => 280
	i32 2411328690, ; 406: Microsoft.AspNetCore.Components => 0x8fb9f4b2 => 193
	i32 2421380589, ; 407: System.Threading.Tasks.Dataflow => 0x905355ed => 141
	i32 2423080555, ; 408: Xamarin.AndroidX.Collection.Ktx.dll => 0x906d466b => 267
	i32 2427813419, ; 409: hi\Microsoft.Maui.Controls.resources => 0x90b57e2b => 344
	i32 2435356389, ; 410: System.Console.dll => 0x912896e5 => 20
	i32 2435904999, ; 411: System.ComponentModel.DataAnnotations.dll => 0x9130f5e7 => 14
	i32 2440640454, ; 412: ProyectoManhattan.Domain => 0x917937c6 => 370
	i32 2442556106, ; 413: Microsoft.JSInterop.dll => 0x919672ca => 239
	i32 2448339309, ; 414: WebDriver => 0x91eeb16d => 249
	i32 2454642406, ; 415: System.Text.Encoding.dll => 0x924edee6 => 135
	i32 2458592288, ; 416: Microsoft.AspNetCore.Authentication.Core => 0x928b2420 => 190
	i32 2458678730, ; 417: System.Net.Sockets.dll => 0x928c75ca => 75
	i32 2459001652, ; 418: System.Linq.Parallel.dll => 0x92916334 => 59
	i32 2465532216, ; 419: Xamarin.AndroidX.ConstraintLayout.Core.dll => 0x92f50938 => 270
	i32 2471841756, ; 420: netstandard.dll => 0x93554fdc => 167
	i32 2475788418, ; 421: Java.Interop.dll => 0x93918882 => 168
	i32 2480646305, ; 422: Microsoft.Maui.Controls => 0x93dba8a1 => 241
	i32 2483903535, ; 423: System.ComponentModel.EventBasedAsync => 0x940d5c2f => 15
	i32 2484371297, ; 424: System.Net.ServicePoint => 0x94147f61 => 74
	i32 2490993605, ; 425: System.AppContext.dll => 0x94798bc5 => 6
	i32 2498657740, ; 426: BouncyCastle.Cryptography.dll => 0x94ee7dcc => 173
	i32 2501346920, ; 427: System.Data.DataSetExtensions => 0x95178668 => 23
	i32 2505896520, ; 428: Xamarin.AndroidX.Lifecycle.Runtime.dll => 0x955cf248 => 292
	i32 2522472828, ; 429: Xamarin.Android.Glide.dll => 0x9659e17c => 251
	i32 2537015816, ; 430: Microsoft.AspNetCore.Authorization => 0x9737ca08 => 191
	i32 2538310050, ; 431: System.Reflection.Emit.Lightweight.dll => 0x974b89a2 => 91
	i32 2550873716, ; 432: hr\Microsoft.Maui.Controls.resources => 0x980b3e74 => 345
	i32 2562349572, ; 433: Microsoft.CSharp => 0x98ba5a04 => 1
	i32 2566497382, ; 434: itext.bouncy-castle-connector => 0x98f9a466 => 176
	i32 2570120770, ; 435: System.Text.Encodings.Web => 0x9930ee42 => 136
	i32 2573607077, ; 436: itext.kernel => 0x996620a5 => 179
	i32 2581783588, ; 437: Xamarin.AndroidX.Lifecycle.Runtime.Ktx => 0x99e2e424 => 293
	i32 2581819634, ; 438: Xamarin.AndroidX.VectorDrawable.dll => 0x99e370f2 => 315
	i32 2585220780, ; 439: System.Text.Encoding.Extensions.dll => 0x9a1756ac => 134
	i32 2585805581, ; 440: System.Net.Ping => 0x9a20430d => 69
	i32 2585813321, ; 441: Microsoft.AspNetCore.Components.Forms => 0x9a206149 => 194
	i32 2589602615, ; 442: System.Threading.ThreadPool => 0x9a5a3337 => 146
	i32 2592341985, ; 443: Microsoft.Extensions.FileProviders.Abstractions => 0x9a83ffe1 => 225
	i32 2593268061, ; 444: Microsoft.AspNetCore.Routing.Abstractions.dll => 0x9a92215d => 209
	i32 2593496499, ; 445: pl\Microsoft.Maui.Controls.resources => 0x9a959db3 => 354
	i32 2594125473, ; 446: Microsoft.AspNetCore.Hosting.Abstractions => 0x9a9f36a1 => 198
	i32 2605712449, ; 447: Xamarin.KotlinX.Coroutines.Core.Jvm => 0x9b500441 => 333
	i32 2615233544, ; 448: Xamarin.AndroidX.Fragment.Ktx => 0x9be14c08 => 284
	i32 2616218305, ; 449: Microsoft.Extensions.Logging.Debug.dll => 0x9bf052c1 => 235
	i32 2617129537, ; 450: System.Private.Xml.dll => 0x9bfe3a41 => 88
	i32 2618712057, ; 451: System.Reflection.TypeExtensions.dll => 0x9c165ff9 => 96
	i32 2620871830, ; 452: Xamarin.AndroidX.CursorAdapter.dll => 0x9c375496 => 274
	i32 2624644809, ; 453: Xamarin.AndroidX.DynamicAnimation => 0x9c70e6c9 => 279
	i32 2626831493, ; 454: ja\Microsoft.Maui.Controls.resources => 0x9c924485 => 349
	i32 2627185994, ; 455: System.Diagnostics.TextWriterTraceListener.dll => 0x9c97ad4a => 31
	i32 2629843544, ; 456: System.IO.Compression.ZipFile.dll => 0x9cc03a58 => 45
	i32 2633051222, ; 457: Xamarin.AndroidX.Lifecycle.LiveData => 0x9cf12c56 => 288
	i32 2633959305, ; 458: Microsoft.AspNetCore.Http.Extensions.dll => 0x9cff0789 => 202
	i32 2663391936, ; 459: Xamarin.Android.Glide.DiskLruCache => 0x9ec022c0 => 253
	i32 2663698177, ; 460: System.Runtime.Loader => 0x9ec4cf01 => 109
	i32 2664396074, ; 461: System.Xml.XDocument.dll => 0x9ecf752a => 158
	i32 2665622720, ; 462: System.Drawing.Primitives => 0x9ee22cc0 => 35
	i32 2676780864, ; 463: System.Data.Common.dll => 0x9f8c6f40 => 22
	i32 2686887180, ; 464: System.Runtime.Serialization.Xml.dll => 0xa026a50c => 114
	i32 2692077919, ; 465: Microsoft.AspNetCore.Components.WebView.dll => 0xa075d95f => 196
	i32 2693849962, ; 466: System.IO.dll => 0xa090e36a => 57
	i32 2701096212, ; 467: Xamarin.AndroidX.Tracing.Tracing => 0xa0ff7514 => 313
	i32 2715334215, ; 468: System.Threading.Tasks.dll => 0xa1d8b647 => 144
	i32 2717744543, ; 469: System.Security.Claims => 0xa1fd7d9f => 118
	i32 2719963679, ; 470: System.Security.Cryptography.Cng.dll => 0xa21f5a1f => 120
	i32 2724373263, ; 471: System.Runtime.Numerics.dll => 0xa262a30f => 110
	i32 2732626843, ; 472: Xamarin.AndroidX.Activity => 0xa2e0939b => 255
	i32 2735172069, ; 473: System.Threading.Channels => 0xa30769e5 => 139
	i32 2735631878, ; 474: Microsoft.AspNetCore.Authorization.dll => 0xa30e6e06 => 191
	i32 2737747696, ; 475: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0xa32eb6f0 => 261
	i32 2740948882, ; 476: System.IO.Pipes.AccessControl => 0xa35f8f92 => 54
	i32 2748088231, ; 477: System.Runtime.InteropServices.JavaScript => 0xa3cc7fa7 => 105
	i32 2752995522, ; 478: pt-BR\Microsoft.Maui.Controls.resources => 0xa41760c2 => 355
	i32 2758225723, ; 479: Microsoft.Maui.Controls.Xaml => 0xa4672f3b => 242
	i32 2764765095, ; 480: Microsoft.Maui.dll => 0xa4caf7a7 => 243
	i32 2765824710, ; 481: System.Text.Encoding.CodePages.dll => 0xa4db22c6 => 133
	i32 2770495804, ; 482: Xamarin.Jetbrains.Annotations.dll => 0xa522693c => 327
	i32 2778768386, ; 483: Xamarin.AndroidX.ViewPager.dll => 0xa5a0a402 => 318
	i32 2779977773, ; 484: Xamarin.AndroidX.ResourceInspection.Annotation.dll => 0xa5b3182d => 306
	i32 2785988530, ; 485: th\Microsoft.Maui.Controls.resources => 0xa60ecfb2 => 361
	i32 2788224221, ; 486: Xamarin.AndroidX.Fragment.Ktx.dll => 0xa630ecdd => 284
	i32 2801831435, ; 487: Microsoft.Maui.Graphics => 0xa7008e0b => 245
	i32 2803228030, ; 488: System.Xml.XPath.XDocument.dll => 0xa715dd7e => 159
	i32 2806116107, ; 489: es/Microsoft.Maui.Controls.resources.dll => 0xa741ef0b => 340
	i32 2810250172, ; 490: Xamarin.AndroidX.CoordinatorLayout.dll => 0xa78103bc => 271
	i32 2819470561, ; 491: System.Xml.dll => 0xa80db4e1 => 163
	i32 2820942282, ; 492: MudBlazor.dll => 0xa82429ca => 247
	i32 2821205001, ; 493: System.ServiceProcess.dll => 0xa8282c09 => 132
	i32 2821294376, ; 494: Xamarin.AndroidX.ResourceInspection.Annotation => 0xa8298928 => 306
	i32 2824502124, ; 495: System.Xml.XmlDocument => 0xa85a7b6c => 161
	i32 2831556043, ; 496: nl/Microsoft.Maui.Controls.resources.dll => 0xa8c61dcb => 353
	i32 2833784645, ; 497: Microsoft.AspNetCore.Metadata => 0xa8e81f45 => 204
	i32 2838993487, ; 498: Xamarin.AndroidX.Lifecycle.ViewModel.Ktx.dll => 0xa9379a4f => 295
	i32 2849599387, ; 499: System.Threading.Overlapped.dll => 0xa9d96f9b => 140
	i32 2850549256, ; 500: Microsoft.AspNetCore.Http.Features => 0xa9e7ee08 => 203
	i32 2853208004, ; 501: Xamarin.AndroidX.ViewPager => 0xaa107fc4 => 318
	i32 2855708567, ; 502: Xamarin.AndroidX.Transition => 0xaa36a797 => 314
	i32 2861098320, ; 503: Mono.Android.Export.dll => 0xaa88e550 => 169
	i32 2861189240, ; 504: Microsoft.Maui.Essentials => 0xaa8a4878 => 244
	i32 2870099610, ; 505: Xamarin.AndroidX.Activity.Ktx.dll => 0xab123e9a => 256
	i32 2872336925, ; 506: ProyectoManhattan.BlazorComponents => 0xab34621d => 369
	i32 2875164099, ; 507: Jsr305Binding.dll => 0xab5f85c3 => 323
	i32 2875220617, ; 508: System.Globalization.Calendars.dll => 0xab606289 => 40
	i32 2884993177, ; 509: Xamarin.AndroidX.ExifInterface => 0xabf58099 => 282
	i32 2887636118, ; 510: System.Net.dll => 0xac1dd496 => 81
	i32 2892341533, ; 511: Microsoft.AspNetCore.Components.Web => 0xac65a11d => 195
	i32 2899753641, ; 512: System.IO.UnmanagedMemoryStream => 0xacd6baa9 => 56
	i32 2900621748, ; 513: System.Dynamic.Runtime.dll => 0xace3f9b4 => 37
	i32 2901442782, ; 514: System.Reflection => 0xacf080de => 97
	i32 2904941990, ; 515: ProyectoManhattan.MAUI.dll => 0xad25e5a6 => 0
	i32 2905242038, ; 516: mscorlib.dll => 0xad2a79b6 => 166
	i32 2908639175, ; 517: itext.sign => 0xad5e4fc7 => 183
	i32 2909740682, ; 518: System.Private.CoreLib => 0xad6f1e8a => 172
	i32 2911054922, ; 519: Microsoft.Extensions.FileProviders.Physical.dll => 0xad832c4a => 228
	i32 2916838712, ; 520: Xamarin.AndroidX.ViewPager2.dll => 0xaddb6d38 => 319
	i32 2919462931, ; 521: System.Numerics.Vectors.dll => 0xae037813 => 82
	i32 2921128767, ; 522: Xamarin.AndroidX.Annotation.Experimental.dll => 0xae1ce33f => 258
	i32 2936416060, ; 523: System.Resources.Reader => 0xaf06273c => 98
	i32 2940926066, ; 524: System.Diagnostics.StackTrace.dll => 0xaf4af872 => 30
	i32 2942453041, ; 525: System.Xml.XPath.XDocument => 0xaf624531 => 159
	i32 2959614098, ; 526: System.ComponentModel.dll => 0xb0682092 => 18
	i32 2968338931, ; 527: System.Security.Principal.Windows => 0xb0ed41f3 => 127
	i32 2972252294, ; 528: System.Security.Cryptography.Algorithms.dll => 0xb128f886 => 119
	i32 2978368250, ; 529: Microsoft.AspNetCore.Hosting.Abstractions.dll => 0xb1864afa => 198
	i32 2978675010, ; 530: Xamarin.AndroidX.DrawerLayout => 0xb18af942 => 278
	i32 2987532451, ; 531: Xamarin.AndroidX.Security.SecurityCrypto => 0xb21220a3 => 309
	i32 2996646946, ; 532: Microsoft.AspNetCore.Http => 0xb29d3422 => 200
	i32 2996846495, ; 533: Xamarin.AndroidX.Lifecycle.Process.dll => 0xb2a03f9f => 291
	i32 3016983068, ; 534: Xamarin.AndroidX.Startup.StartupRuntime => 0xb3d3821c => 311
	i32 3023353419, ; 535: WindowsBase.dll => 0xb434b64b => 165
	i32 3024354802, ; 536: Xamarin.AndroidX.Legacy.Support.Core.Utils => 0xb443fdf2 => 286
	i32 3033331042, ; 537: Microsoft.AspNetCore.Authentication.Core.dll => 0xb4ccf562 => 190
	i32 3036999524, ; 538: Microsoft.AspNetCore.Http.Extensions => 0xb504ef64 => 202
	i32 3038032645, ; 539: _Microsoft.Android.Resource.Designer.dll => 0xb514b305 => 371
	i32 3056245963, ; 540: Xamarin.AndroidX.SavedState.SavedState.Ktx => 0xb62a9ccb => 308
	i32 3057625584, ; 541: Xamarin.AndroidX.Navigation.Common => 0xb63fa9f0 => 299
	i32 3059408633, ; 542: Mono.Android.Runtime => 0xb65adef9 => 170
	i32 3059793426, ; 543: System.ComponentModel.Primitives => 0xb660be12 => 16
	i32 3060069052, ; 544: MudBlazor => 0xb664f2bc => 247
	i32 3069363400, ; 545: Microsoft.Extensions.Caching.Abstractions.dll => 0xb6f2c4c8 => 214
	i32 3075834255, ; 546: System.Threading.Tasks => 0xb755818f => 144
	i32 3077302341, ; 547: hu/Microsoft.Maui.Controls.resources.dll => 0xb76be845 => 346
	i32 3090735792, ; 548: System.Security.Cryptography.X509Certificates.dll => 0xb838e2b0 => 125
	i32 3099732863, ; 549: System.Security.Claims.dll => 0xb8c22b7f => 118
	i32 3103600923, ; 550: System.Formats.Asn1 => 0xb8fd311b => 38
	i32 3111772706, ; 551: System.Runtime.Serialization => 0xb979e222 => 115
	i32 3113762169, ; 552: Microsoft.AspNetCore.Routing.Abstractions => 0xb9983d79 => 209
	i32 3121463068, ; 553: System.IO.FileSystem.AccessControl.dll => 0xba0dbf1c => 47
	i32 3124832203, ; 554: System.Threading.Tasks.Extensions => 0xba4127cb => 142
	i32 3132293585, ; 555: System.Security.AccessControl => 0xbab301d1 => 117
	i32 3146401616, ; 556: itext.styledxmlparser => 0xbb8a4750 => 184
	i32 3147165239, ; 557: System.Diagnostics.Tracing.dll => 0xbb95ee37 => 34
	i32 3148237826, ; 558: GoogleGson.dll => 0xbba64c02 => 174
	i32 3151576809, ; 559: Microsoft.AspNetCore.Mvc.Core => 0xbbd93ee9 => 206
	i32 3159123045, ; 560: System.Reflection.Primitives.dll => 0xbc4c6465 => 95
	i32 3160747431, ; 561: System.IO.MemoryMappedFiles => 0xbc652da7 => 53
	i32 3178803400, ; 562: Xamarin.AndroidX.Navigation.Fragment.dll => 0xbd78b0c8 => 300
	i32 3192346100, ; 563: System.Security.SecureString => 0xbe4755f4 => 129
	i32 3193515020, ; 564: System.Web => 0xbe592c0c => 153
	i32 3195844289, ; 565: Microsoft.Extensions.Caching.Abstractions => 0xbe7cb6c1 => 214
	i32 3204380047, ; 566: System.Data.dll => 0xbefef58f => 24
	i32 3209718065, ; 567: System.Xml.XmlDocument.dll => 0xbf506931 => 161
	i32 3211777861, ; 568: Xamarin.AndroidX.DocumentFile => 0xbf6fd745 => 277
	i32 3220365878, ; 569: System.Threading => 0xbff2e236 => 148
	i32 3226221578, ; 570: System.Runtime.Handles.dll => 0xc04c3c0a => 104
	i32 3228018376, ; 571: Microsoft.AspNetCore.ResponseCaching.Abstractions.dll => 0xc067a6c8 => 207
	i32 3251039220, ; 572: System.Reflection.DispatchProxy.dll => 0xc1c6ebf4 => 89
	i32 3258312781, ; 573: Xamarin.AndroidX.CardView => 0xc235e84d => 265
	i32 3265493905, ; 574: System.Linq.Queryable.dll => 0xc2a37b91 => 60
	i32 3265893370, ; 575: System.Threading.Tasks.Extensions.dll => 0xc2a993fa => 142
	i32 3277815716, ; 576: System.Resources.Writer.dll => 0xc35f7fa4 => 100
	i32 3279906254, ; 577: Microsoft.Win32.Registry.dll => 0xc37f65ce => 5
	i32 3280506390, ; 578: System.ComponentModel.Annotations.dll => 0xc3888e16 => 13
	i32 3290767353, ; 579: System.Security.Cryptography.Encoding => 0xc4251ff9 => 122
	i32 3299363146, ; 580: System.Text.Encoding => 0xc4a8494a => 135
	i32 3300764913, ; 581: Microsoft.AspNetCore.WebUtilities => 0xc4bdacf1 => 210
	i32 3303498502, ; 582: System.Diagnostics.FileVersionInfo => 0xc4e76306 => 28
	i32 3305363605, ; 583: fi\Microsoft.Maui.Controls.resources => 0xc503d895 => 341
	i32 3316684772, ; 584: System.Net.Requests.dll => 0xc5b097e4 => 72
	i32 3317135071, ; 585: Xamarin.AndroidX.CustomView.dll => 0xc5b776df => 275
	i32 3317144872, ; 586: System.Data => 0xc5b79d28 => 24
	i32 3340431453, ; 587: Xamarin.AndroidX.Arch.Core.Runtime => 0xc71af05d => 263
	i32 3342793838, ; 588: itext.barcodes => 0xc73efc6e => 175
	i32 3345895724, ; 589: Xamarin.AndroidX.ProfileInstaller.ProfileInstaller.dll => 0xc76e512c => 304
	i32 3346324047, ; 590: Xamarin.AndroidX.Navigation.Runtime => 0xc774da4f => 301
	i32 3354930595, ; 591: Mailjet.Client => 0xc7f82da3 => 188
	i32 3357674450, ; 592: ru\Microsoft.Maui.Controls.resources => 0xc8220bd2 => 358
	i32 3358260929, ; 593: System.Text.Json => 0xc82afec1 => 137
	i32 3362336904, ; 594: Xamarin.AndroidX.Activity.Ktx => 0xc8693088 => 256
	i32 3362522851, ; 595: Xamarin.AndroidX.Core => 0xc86c06e3 => 272
	i32 3366347497, ; 596: Java.Interop => 0xc8a662e9 => 168
	i32 3374999561, ; 597: Xamarin.AndroidX.RecyclerView => 0xc92a6809 => 305
	i32 3381016424, ; 598: da\Microsoft.Maui.Controls.resources => 0xc9863768 => 337
	i32 3395150330, ; 599: System.Runtime.CompilerServices.Unsafe.dll => 0xca5de1fa => 101
	i32 3403906625, ; 600: System.Security.Cryptography.OpenSsl.dll => 0xcae37e41 => 123
	i32 3405233483, ; 601: Xamarin.AndroidX.CustomView.PoolingContainer => 0xcaf7bd4b => 276
	i32 3406629867, ; 602: Microsoft.Extensions.FileProviders.Composite.dll => 0xcb0d0beb => 226
	i32 3421170118, ; 603: Microsoft.Extensions.Configuration.Binder => 0xcbeae9c6 => 218
	i32 3428513518, ; 604: Microsoft.Extensions.DependencyInjection.dll => 0xcc5af6ee => 221
	i32 3429136800, ; 605: System.Xml => 0xcc6479a0 => 163
	i32 3430777524, ; 606: netstandard => 0xcc7d82b4 => 167
	i32 3441283291, ; 607: Xamarin.AndroidX.DynamicAnimation.dll => 0xcd1dd0db => 279
	i32 3445260447, ; 608: System.Formats.Tar => 0xcd5a809f => 39
	i32 3452344032, ; 609: Microsoft.Maui.Controls.Compatibility.dll => 0xcdc696e0 => 240
	i32 3463511458, ; 610: hr/Microsoft.Maui.Controls.resources.dll => 0xce70fda2 => 345
	i32 3464190856, ; 611: Microsoft.AspNetCore.Components.Forms.dll => 0xce7b5b88 => 194
	i32 3471940407, ; 612: System.ComponentModel.TypeConverter.dll => 0xcef19b37 => 17
	i32 3476120550, ; 613: Mono.Android => 0xcf3163e6 => 171
	i32 3479583265, ; 614: ru/Microsoft.Maui.Controls.resources.dll => 0xcf663a21 => 358
	i32 3484440000, ; 615: ro\Microsoft.Maui.Controls.resources => 0xcfb055c0 => 357
	i32 3485117614, ; 616: System.Text.Json.dll => 0xcfbaacae => 137
	i32 3486566296, ; 617: System.Transactions => 0xcfd0c798 => 150
	i32 3493954962, ; 618: Xamarin.AndroidX.Concurrent.Futures.dll => 0xd0418592 => 268
	i32 3500000672, ; 619: Microsoft.JSInterop => 0xd09dc5a0 => 239
	i32 3509114376, ; 620: System.Xml.Linq => 0xd128d608 => 155
	i32 3515174580, ; 621: System.Security.dll => 0xd1854eb4 => 130
	i32 3530912306, ; 622: System.Configuration => 0xd2757232 => 19
	i32 3539954161, ; 623: System.Net.HttpListener => 0xd2ff69f1 => 65
	i32 3547693875, ; 624: Mailjet.Client.dll => 0xd3758333 => 188
	i32 3556501504, ; 625: ProyectoManhattan.Application => 0xd3fbe800 => 368
	i32 3560100363, ; 626: System.Threading.Timer => 0xd432d20b => 147
	i32 3570554715, ; 627: System.IO.FileSystem.AccessControl => 0xd4d2575b => 47
	i32 3580758918, ; 628: zh-HK\Microsoft.Maui.Controls.resources => 0xd56e0b86 => 365
	i32 3592435036, ; 629: Microsoft.Extensions.Localization.Abstractions => 0xd620355c => 232
	i32 3597029428, ; 630: Xamarin.Android.Glide.GifDecoder.dll => 0xd6665034 => 254
	i32 3598340787, ; 631: System.Net.WebSockets.Client => 0xd67a52b3 => 79
	i32 3605570793, ; 632: BouncyCastle.Cryptography => 0xd6e8a4e9 => 173
	i32 3608519521, ; 633: System.Linq.dll => 0xd715a361 => 61
	i32 3624195450, ; 634: System.Runtime.InteropServices.RuntimeInformation => 0xd804d57a => 106
	i32 3627220390, ; 635: Xamarin.AndroidX.Print.dll => 0xd832fda6 => 303
	i32 3633644679, ; 636: Xamarin.AndroidX.Annotation.Experimental => 0xd8950487 => 258
	i32 3637786959, ; 637: itext.sign.dll => 0xd8d4394f => 183
	i32 3638274909, ; 638: System.IO.FileSystem.Primitives.dll => 0xd8dbab5d => 49
	i32 3641597786, ; 639: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0xd90e5f5a => 289
	i32 3643446276, ; 640: tr\Microsoft.Maui.Controls.resources => 0xd92a9404 => 362
	i32 3643854240, ; 641: Xamarin.AndroidX.Navigation.Fragment => 0xd930cda0 => 300
	i32 3645089577, ; 642: System.ComponentModel.DataAnnotations => 0xd943a729 => 14
	i32 3657292374, ; 643: Microsoft.Extensions.Configuration.Abstractions.dll => 0xd9fdda56 => 217
	i32 3660523487, ; 644: System.Net.NetworkInformation => 0xda2f27df => 68
	i32 3672681054, ; 645: Mono.Android.dll => 0xdae8aa5e => 171
	i32 3682565725, ; 646: Xamarin.AndroidX.Browser => 0xdb7f7e5d => 264
	i32 3684561358, ; 647: Xamarin.AndroidX.Concurrent.Futures => 0xdb9df1ce => 268
	i32 3684657769, ; 648: itext.commons => 0xdb9f6a69 => 187
	i32 3697841164, ; 649: zh-Hant/Microsoft.Maui.Controls.resources.dll => 0xdc68940c => 367
	i32 3700866549, ; 650: System.Net.WebProxy.dll => 0xdc96bdf5 => 78
	i32 3706696989, ; 651: Xamarin.AndroidX.Core.Core.Ktx.dll => 0xdcefb51d => 273
	i32 3716563718, ; 652: System.Runtime.Intrinsics => 0xdd864306 => 108
	i32 3718780102, ; 653: Xamarin.AndroidX.Annotation => 0xdda814c6 => 257
	i32 3722202641, ; 654: Microsoft.Extensions.Configuration.Json.dll => 0xdddc4e11 => 220
	i32 3724971120, ; 655: Xamarin.AndroidX.Navigation.Common.dll => 0xde068c70 => 299
	i32 3732100267, ; 656: System.Net.NameResolution => 0xde7354ab => 67
	i32 3732214720, ; 657: Microsoft.AspNetCore.Metadata.dll => 0xde7513c0 => 204
	i32 3737834244, ; 658: System.Net.Http.Json.dll => 0xdecad304 => 63
	i32 3748608112, ; 659: System.Diagnostics.DiagnosticSource => 0xdf6f3870 => 27
	i32 3751444290, ; 660: System.Xml.XPath => 0xdf9a7f42 => 160
	i32 3758424670, ; 661: Microsoft.Extensions.Configuration.FileExtensions => 0xe005025e => 219
	i32 3765508441, ; 662: Microsoft.Extensions.ObjectPool.dll => 0xe0711959 => 236
	i32 3776403777, ; 663: Microsoft.Extensions.Localization.Abstractions.dll => 0xe1175941 => 232
	i32 3786282454, ; 664: Xamarin.AndroidX.Collection => 0xe1ae15d6 => 266
	i32 3792276235, ; 665: System.Collections.NonGeneric => 0xe2098b0b => 10
	i32 3800979733, ; 666: Microsoft.Maui.Controls.Compatibility => 0xe28e5915 => 240
	i32 3802395368, ; 667: System.Collections.Specialized.dll => 0xe2a3f2e8 => 11
	i32 3819260425, ; 668: System.Net.WebProxy => 0xe3a54a09 => 78
	i32 3823082795, ; 669: System.Security.Cryptography.dll => 0xe3df9d2b => 126
	i32 3829621856, ; 670: System.Numerics.dll => 0xe4436460 => 83
	i32 3841636137, ; 671: Microsoft.Extensions.DependencyInjection.Abstractions.dll => 0xe4fab729 => 222
	i32 3844307129, ; 672: System.Net.Mail.dll => 0xe52378b9 => 66
	i32 3849253459, ; 673: System.Runtime.InteropServices.dll => 0xe56ef253 => 107
	i32 3870376305, ; 674: System.Net.HttpListener.dll => 0xe6b14171 => 65
	i32 3873536506, ; 675: System.Security.Principal => 0xe6e179fa => 128
	i32 3875112723, ; 676: System.Security.Cryptography.Encoding.dll => 0xe6f98713 => 122
	i32 3885497537, ; 677: System.Net.WebHeaderCollection.dll => 0xe797fcc1 => 77
	i32 3885922214, ; 678: Xamarin.AndroidX.Transition.dll => 0xe79e77a6 => 314
	i32 3888767677, ; 679: Xamarin.AndroidX.ProfileInstaller.ProfileInstaller => 0xe7c9e2bd => 304
	i32 3889960447, ; 680: zh-Hans/Microsoft.Maui.Controls.resources.dll => 0xe7dc15ff => 366
	i32 3896106733, ; 681: System.Collections.Concurrent.dll => 0xe839deed => 8
	i32 3896760992, ; 682: Xamarin.AndroidX.Core.dll => 0xe843daa0 => 272
	i32 3898862222, ; 683: itext.layout.dll => 0xe863ea8e => 180
	i32 3898971068, ; 684: Microsoft.Extensions.Localization.dll => 0xe86593bc => 231
	i32 3901907137, ; 685: Microsoft.VisualBasic.Core.dll => 0xe89260c1 => 2
	i32 3920810846, ; 686: System.IO.Compression.FileSystem.dll => 0xe9b2d35e => 44
	i32 3921031405, ; 687: Xamarin.AndroidX.VersionedParcelable.dll => 0xe9b630ed => 317
	i32 3928044579, ; 688: System.Xml.ReaderWriter => 0xea213423 => 156
	i32 3930554604, ; 689: System.Security.Principal.dll => 0xea4780ec => 128
	i32 3931092270, ; 690: Xamarin.AndroidX.Navigation.UI => 0xea4fb52e => 302
	i32 3945557071, ; 691: ProyectoManhattan.Application.dll => 0xeb2c6c4f => 368
	i32 3945713374, ; 692: System.Data.DataSetExtensions.dll => 0xeb2ecede => 23
	i32 3953953790, ; 693: System.Text.Encoding.CodePages => 0xebac8bfe => 133
	i32 3954195687, ; 694: Microsoft.Extensions.Localization => 0xebb03ce7 => 231
	i32 3955647286, ; 695: Xamarin.AndroidX.AppCompat.dll => 0xebc66336 => 260
	i32 3959773229, ; 696: Xamarin.AndroidX.Lifecycle.Process => 0xec05582d => 291
	i32 3971066695, ; 697: itext.styledxmlparser.dll => 0xecb1ab47 => 184
	i32 3977646153, ; 698: itext.io.dll => 0xed161049 => 178
	i32 3980434154, ; 699: th/Microsoft.Maui.Controls.resources.dll => 0xed409aea => 361
	i32 3987592930, ; 700: he/Microsoft.Maui.Controls.resources.dll => 0xedadd6e2 => 343
	i32 4003436829, ; 701: System.Diagnostics.Process.dll => 0xee9f991d => 29
	i32 4015948917, ; 702: Xamarin.AndroidX.Annotation.Jvm.dll => 0xef5e8475 => 259
	i32 4023392905, ; 703: System.IO.Pipelines => 0xefd01a89 => 250
	i32 4025784931, ; 704: System.Memory => 0xeff49a63 => 62
	i32 4044155772, ; 705: Microsoft.Net.Http.Headers.dll => 0xf10ceb7c => 246
	i32 4046471985, ; 706: Microsoft.Maui.Controls.Xaml.dll => 0xf1304331 => 242
	i32 4054681211, ; 707: System.Reflection.Emit.ILGeneration => 0xf1ad867b => 90
	i32 4068434129, ; 708: System.Private.Xml.Linq.dll => 0xf27f60d1 => 87
	i32 4073602200, ; 709: System.Threading.dll => 0xf2ce3c98 => 148
	i32 4078967171, ; 710: Microsoft.Extensions.Hosting.Abstractions.dll => 0xf3201983 => 230
	i32 4091293555, ; 711: itext.forms.dll => 0xf3dc2f73 => 177
	i32 4092658563, ; 712: itext.bouncy-castle-adapter.dll => 0xf3f10383 => 186
	i32 4094352644, ; 713: Microsoft.Maui.Essentials.dll => 0xf40add04 => 244
	i32 4099507663, ; 714: System.Drawing.dll => 0xf45985cf => 36
	i32 4100113165, ; 715: System.Private.Uri => 0xf462c30d => 86
	i32 4101593132, ; 716: Xamarin.AndroidX.Emoji2 => 0xf479582c => 280
	i32 4101842092, ; 717: Microsoft.Extensions.Caching.Memory => 0xf47d24ac => 215
	i32 4102112229, ; 718: pt/Microsoft.Maui.Controls.resources.dll => 0xf48143e5 => 356
	i32 4125707920, ; 719: ms/Microsoft.Maui.Controls.resources.dll => 0xf5e94e90 => 351
	i32 4126470640, ; 720: Microsoft.Extensions.DependencyInjection => 0xf5f4f1f0 => 221
	i32 4127667938, ; 721: System.IO.FileSystem.Watcher => 0xf60736e2 => 50
	i32 4130442656, ; 722: System.AppContext => 0xf6318da0 => 6
	i32 4141580284, ; 723: Microsoft.AspNetCore.Authorization.Policy => 0xf6db7ffc => 192
	i32 4147896353, ; 724: System.Reflection.Emit.ILGeneration.dll => 0xf73be021 => 90
	i32 4150914736, ; 725: uk\Microsoft.Maui.Controls.resources => 0xf769eeb0 => 363
	i32 4151237749, ; 726: System.Core => 0xf76edc75 => 21
	i32 4159265925, ; 727: System.Xml.XmlSerializer => 0xf7e95c85 => 162
	i32 4161255271, ; 728: System.Reflection.TypeExtensions => 0xf807b767 => 96
	i32 4164802419, ; 729: System.IO.FileSystem.Watcher.dll => 0xf83dd773 => 50
	i32 4181436372, ; 730: System.Runtime.Serialization.Primitives => 0xf93ba7d4 => 113
	i32 4182413190, ; 731: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0xf94a8f86 => 296
	i32 4185676441, ; 732: System.Security => 0xf97c5a99 => 130
	i32 4186523351, ; 733: itext.svg.dll => 0xf98946d7 => 185
	i32 4196529839, ; 734: System.Net.WebClient.dll => 0xfa21f6af => 76
	i32 4213026141, ; 735: System.Diagnostics.DiagnosticSource.dll => 0xfb1dad5d => 27
	i32 4256097574, ; 736: Xamarin.AndroidX.Core.Core.Ktx => 0xfdaee526 => 273
	i32 4258378803, ; 737: Xamarin.AndroidX.Lifecycle.ViewModel.Ktx => 0xfdd1b433 => 295
	i32 4260525087, ; 738: System.Buffers => 0xfdf2741f => 7
	i32 4271975918, ; 739: Microsoft.Maui.Controls.dll => 0xfea12dee => 241
	i32 4274976490, ; 740: System.Runtime.Numerics => 0xfecef6ea => 110
	i32 4292120959, ; 741: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xffd4917f => 296
	i32 4294648842, ; 742: Microsoft.Extensions.FileProviders.Embedded => 0xfffb240a => 227
	i32 4294763496 ; 743: Xamarin.AndroidX.ExifInterface.dll => 0xfffce3e8 => 282
], align 4

@assembly_image_cache_indices = dso_local local_unnamed_addr constant [744 x i32] [
	i32 68, ; 0
	i32 67, ; 1
	i32 108, ; 2
	i32 223, ; 3
	i32 292, ; 4
	i32 326, ; 5
	i32 48, ; 6
	i32 248, ; 7
	i32 80, ; 8
	i32 145, ; 9
	i32 249, ; 10
	i32 30, ; 11
	i32 367, ; 12
	i32 124, ; 13
	i32 245, ; 14
	i32 102, ; 15
	i32 224, ; 16
	i32 310, ; 17
	i32 107, ; 18
	i32 310, ; 19
	i32 139, ; 20
	i32 330, ; 21
	i32 77, ; 22
	i32 124, ; 23
	i32 13, ; 24
	i32 266, ; 25
	i32 132, ; 26
	i32 210, ; 27
	i32 312, ; 28
	i32 151, ; 29
	i32 364, ; 30
	i32 365, ; 31
	i32 18, ; 32
	i32 264, ; 33
	i32 26, ; 34
	i32 286, ; 35
	i32 1, ; 36
	i32 59, ; 37
	i32 42, ; 38
	i32 91, ; 39
	i32 193, ; 40
	i32 269, ; 41
	i32 147, ; 42
	i32 288, ; 43
	i32 285, ; 44
	i32 336, ; 45
	i32 54, ; 46
	i32 69, ; 47
	i32 189, ; 48
	i32 364, ; 49
	i32 255, ; 50
	i32 83, ; 51
	i32 349, ; 52
	i32 287, ; 53
	i32 207, ; 54
	i32 348, ; 55
	i32 131, ; 56
	i32 55, ; 57
	i32 149, ; 58
	i32 74, ; 59
	i32 145, ; 60
	i32 208, ; 61
	i32 62, ; 62
	i32 146, ; 63
	i32 371, ; 64
	i32 165, ; 65
	i32 360, ; 66
	i32 270, ; 67
	i32 12, ; 68
	i32 283, ; 69
	i32 125, ; 70
	i32 152, ; 71
	i32 113, ; 72
	i32 166, ; 73
	i32 164, ; 74
	i32 285, ; 75
	i32 298, ; 76
	i32 199, ; 77
	i32 84, ; 78
	i32 347, ; 79
	i32 341, ; 80
	i32 238, ; 81
	i32 150, ; 82
	i32 330, ; 83
	i32 60, ; 84
	i32 233, ; 85
	i32 51, ; 86
	i32 103, ; 87
	i32 114, ; 88
	i32 40, ; 89
	i32 323, ; 90
	i32 321, ; 91
	i32 227, ; 92
	i32 120, ; 93
	i32 355, ; 94
	i32 52, ; 95
	i32 44, ; 96
	i32 180, ; 97
	i32 119, ; 98
	i32 275, ; 99
	i32 353, ; 100
	i32 281, ; 101
	i32 81, ; 102
	i32 136, ; 103
	i32 317, ; 104
	i32 262, ; 105
	i32 8, ; 106
	i32 73, ; 107
	i32 335, ; 108
	i32 155, ; 109
	i32 332, ; 110
	i32 154, ; 111
	i32 92, ; 112
	i32 327, ; 113
	i32 45, ; 114
	i32 350, ; 115
	i32 338, ; 116
	i32 331, ; 117
	i32 109, ; 118
	i32 192, ; 119
	i32 129, ; 120
	i32 25, ; 121
	i32 252, ; 122
	i32 72, ; 123
	i32 55, ; 124
	i32 46, ; 125
	i32 359, ; 126
	i32 237, ; 127
	i32 276, ; 128
	i32 197, ; 129
	i32 22, ; 130
	i32 290, ; 131
	i32 86, ; 132
	i32 43, ; 133
	i32 160, ; 134
	i32 71, ; 135
	i32 303, ; 136
	i32 3, ; 137
	i32 42, ; 138
	i32 63, ; 139
	i32 16, ; 140
	i32 369, ; 141
	i32 53, ; 142
	i32 178, ; 143
	i32 362, ; 144
	i32 326, ; 145
	i32 105, ; 146
	i32 248, ; 147
	i32 331, ; 148
	i32 324, ; 149
	i32 287, ; 150
	i32 175, ; 151
	i32 34, ; 152
	i32 158, ; 153
	i32 85, ; 154
	i32 32, ; 155
	i32 12, ; 156
	i32 51, ; 157
	i32 229, ; 158
	i32 56, ; 159
	i32 0, ; 160
	i32 307, ; 161
	i32 36, ; 162
	i32 222, ; 163
	i32 337, ; 164
	i32 325, ; 165
	i32 260, ; 166
	i32 35, ; 167
	i32 58, ; 168
	i32 224, ; 169
	i32 294, ; 170
	i32 174, ; 171
	i32 177, ; 172
	i32 179, ; 173
	i32 186, ; 174
	i32 17, ; 175
	i32 328, ; 176
	i32 164, ; 177
	i32 211, ; 178
	i32 219, ; 179
	i32 230, ; 180
	i32 189, ; 181
	i32 350, ; 182
	i32 293, ; 183
	i32 235, ; 184
	i32 320, ; 185
	i32 213, ; 186
	i32 356, ; 187
	i32 153, ; 188
	i32 225, ; 189
	i32 316, ; 190
	i32 301, ; 191
	i32 213, ; 192
	i32 354, ; 193
	i32 262, ; 194
	i32 215, ; 195
	i32 29, ; 196
	i32 52, ; 197
	i32 246, ; 198
	i32 182, ; 199
	i32 352, ; 200
	i32 199, ; 201
	i32 321, ; 202
	i32 185, ; 203
	i32 187, ; 204
	i32 5, ; 205
	i32 336, ; 206
	i32 311, ; 207
	i32 315, ; 208
	i32 208, ; 209
	i32 267, ; 210
	i32 332, ; 211
	i32 259, ; 212
	i32 181, ; 213
	i32 278, ; 214
	i32 85, ; 215
	i32 320, ; 216
	i32 61, ; 217
	i32 112, ; 218
	i32 57, ; 219
	i32 366, ; 220
	i32 307, ; 221
	i32 99, ; 222
	i32 19, ; 223
	i32 271, ; 224
	i32 111, ; 225
	i32 101, ; 226
	i32 102, ; 227
	i32 334, ; 228
	i32 104, ; 229
	i32 324, ; 230
	i32 71, ; 231
	i32 38, ; 232
	i32 32, ; 233
	i32 226, ; 234
	i32 103, ; 235
	i32 73, ; 236
	i32 340, ; 237
	i32 9, ; 238
	i32 123, ; 239
	i32 46, ; 240
	i32 261, ; 241
	i32 238, ; 242
	i32 9, ; 243
	i32 43, ; 244
	i32 4, ; 245
	i32 176, ; 246
	i32 308, ; 247
	i32 344, ; 248
	i32 339, ; 249
	i32 229, ; 250
	i32 31, ; 251
	i32 138, ; 252
	i32 92, ; 253
	i32 197, ; 254
	i32 93, ; 255
	i32 359, ; 256
	i32 49, ; 257
	i32 141, ; 258
	i32 112, ; 259
	i32 140, ; 260
	i32 277, ; 261
	i32 115, ; 262
	i32 325, ; 263
	i32 157, ; 264
	i32 76, ; 265
	i32 79, ; 266
	i32 297, ; 267
	i32 37, ; 268
	i32 319, ; 269
	i32 220, ; 270
	i32 281, ; 271
	i32 274, ; 272
	i32 64, ; 273
	i32 138, ; 274
	i32 15, ; 275
	i32 196, ; 276
	i32 116, ; 277
	i32 313, ; 278
	i32 322, ; 279
	i32 269, ; 280
	i32 181, ; 281
	i32 48, ; 282
	i32 70, ; 283
	i32 80, ; 284
	i32 126, ; 285
	i32 212, ; 286
	i32 94, ; 287
	i32 121, ; 288
	i32 370, ; 289
	i32 329, ; 290
	i32 26, ; 291
	i32 290, ; 292
	i32 97, ; 293
	i32 28, ; 294
	i32 265, ; 295
	i32 357, ; 296
	i32 335, ; 297
	i32 149, ; 298
	i32 250, ; 299
	i32 169, ; 300
	i32 4, ; 301
	i32 98, ; 302
	i32 195, ; 303
	i32 33, ; 304
	i32 93, ; 305
	i32 312, ; 306
	i32 233, ; 307
	i32 21, ; 308
	i32 41, ; 309
	i32 170, ; 310
	i32 351, ; 311
	i32 283, ; 312
	i32 343, ; 313
	i32 297, ; 314
	i32 328, ; 315
	i32 322, ; 316
	i32 302, ; 317
	i32 2, ; 318
	i32 203, ; 319
	i32 134, ; 320
	i32 111, ; 321
	i32 234, ; 322
	i32 363, ; 323
	i32 252, ; 324
	i32 360, ; 325
	i32 58, ; 326
	i32 95, ; 327
	i32 342, ; 328
	i32 39, ; 329
	i32 263, ; 330
	i32 25, ; 331
	i32 94, ; 332
	i32 211, ; 333
	i32 89, ; 334
	i32 99, ; 335
	i32 10, ; 336
	i32 201, ; 337
	i32 87, ; 338
	i32 100, ; 339
	i32 309, ; 340
	i32 216, ; 341
	i32 329, ; 342
	i32 254, ; 343
	i32 339, ; 344
	i32 7, ; 345
	i32 294, ; 346
	i32 334, ; 347
	i32 251, ; 348
	i32 88, ; 349
	i32 182, ; 350
	i32 218, ; 351
	i32 289, ; 352
	i32 154, ; 353
	i32 338, ; 354
	i32 33, ; 355
	i32 228, ; 356
	i32 201, ; 357
	i32 116, ; 358
	i32 82, ; 359
	i32 20, ; 360
	i32 11, ; 361
	i32 162, ; 362
	i32 3, ; 363
	i32 243, ; 364
	i32 346, ; 365
	i32 237, ; 366
	i32 206, ; 367
	i32 234, ; 368
	i32 84, ; 369
	i32 223, ; 370
	i32 333, ; 371
	i32 64, ; 372
	i32 236, ; 373
	i32 348, ; 374
	i32 316, ; 375
	i32 143, ; 376
	i32 200, ; 377
	i32 298, ; 378
	i32 157, ; 379
	i32 212, ; 380
	i32 41, ; 381
	i32 117, ; 382
	i32 217, ; 383
	i32 253, ; 384
	i32 342, ; 385
	i32 305, ; 386
	i32 205, ; 387
	i32 131, ; 388
	i32 75, ; 389
	i32 66, ; 390
	i32 352, ; 391
	i32 172, ; 392
	i32 257, ; 393
	i32 143, ; 394
	i32 205, ; 395
	i32 106, ; 396
	i32 151, ; 397
	i32 70, ; 398
	i32 156, ; 399
	i32 216, ; 400
	i32 121, ; 401
	i32 127, ; 402
	i32 347, ; 403
	i32 152, ; 404
	i32 280, ; 405
	i32 193, ; 406
	i32 141, ; 407
	i32 267, ; 408
	i32 344, ; 409
	i32 20, ; 410
	i32 14, ; 411
	i32 370, ; 412
	i32 239, ; 413
	i32 249, ; 414
	i32 135, ; 415
	i32 190, ; 416
	i32 75, ; 417
	i32 59, ; 418
	i32 270, ; 419
	i32 167, ; 420
	i32 168, ; 421
	i32 241, ; 422
	i32 15, ; 423
	i32 74, ; 424
	i32 6, ; 425
	i32 173, ; 426
	i32 23, ; 427
	i32 292, ; 428
	i32 251, ; 429
	i32 191, ; 430
	i32 91, ; 431
	i32 345, ; 432
	i32 1, ; 433
	i32 176, ; 434
	i32 136, ; 435
	i32 179, ; 436
	i32 293, ; 437
	i32 315, ; 438
	i32 134, ; 439
	i32 69, ; 440
	i32 194, ; 441
	i32 146, ; 442
	i32 225, ; 443
	i32 209, ; 444
	i32 354, ; 445
	i32 198, ; 446
	i32 333, ; 447
	i32 284, ; 448
	i32 235, ; 449
	i32 88, ; 450
	i32 96, ; 451
	i32 274, ; 452
	i32 279, ; 453
	i32 349, ; 454
	i32 31, ; 455
	i32 45, ; 456
	i32 288, ; 457
	i32 202, ; 458
	i32 253, ; 459
	i32 109, ; 460
	i32 158, ; 461
	i32 35, ; 462
	i32 22, ; 463
	i32 114, ; 464
	i32 196, ; 465
	i32 57, ; 466
	i32 313, ; 467
	i32 144, ; 468
	i32 118, ; 469
	i32 120, ; 470
	i32 110, ; 471
	i32 255, ; 472
	i32 139, ; 473
	i32 191, ; 474
	i32 261, ; 475
	i32 54, ; 476
	i32 105, ; 477
	i32 355, ; 478
	i32 242, ; 479
	i32 243, ; 480
	i32 133, ; 481
	i32 327, ; 482
	i32 318, ; 483
	i32 306, ; 484
	i32 361, ; 485
	i32 284, ; 486
	i32 245, ; 487
	i32 159, ; 488
	i32 340, ; 489
	i32 271, ; 490
	i32 163, ; 491
	i32 247, ; 492
	i32 132, ; 493
	i32 306, ; 494
	i32 161, ; 495
	i32 353, ; 496
	i32 204, ; 497
	i32 295, ; 498
	i32 140, ; 499
	i32 203, ; 500
	i32 318, ; 501
	i32 314, ; 502
	i32 169, ; 503
	i32 244, ; 504
	i32 256, ; 505
	i32 369, ; 506
	i32 323, ; 507
	i32 40, ; 508
	i32 282, ; 509
	i32 81, ; 510
	i32 195, ; 511
	i32 56, ; 512
	i32 37, ; 513
	i32 97, ; 514
	i32 0, ; 515
	i32 166, ; 516
	i32 183, ; 517
	i32 172, ; 518
	i32 228, ; 519
	i32 319, ; 520
	i32 82, ; 521
	i32 258, ; 522
	i32 98, ; 523
	i32 30, ; 524
	i32 159, ; 525
	i32 18, ; 526
	i32 127, ; 527
	i32 119, ; 528
	i32 198, ; 529
	i32 278, ; 530
	i32 309, ; 531
	i32 200, ; 532
	i32 291, ; 533
	i32 311, ; 534
	i32 165, ; 535
	i32 286, ; 536
	i32 190, ; 537
	i32 202, ; 538
	i32 371, ; 539
	i32 308, ; 540
	i32 299, ; 541
	i32 170, ; 542
	i32 16, ; 543
	i32 247, ; 544
	i32 214, ; 545
	i32 144, ; 546
	i32 346, ; 547
	i32 125, ; 548
	i32 118, ; 549
	i32 38, ; 550
	i32 115, ; 551
	i32 209, ; 552
	i32 47, ; 553
	i32 142, ; 554
	i32 117, ; 555
	i32 184, ; 556
	i32 34, ; 557
	i32 174, ; 558
	i32 206, ; 559
	i32 95, ; 560
	i32 53, ; 561
	i32 300, ; 562
	i32 129, ; 563
	i32 153, ; 564
	i32 214, ; 565
	i32 24, ; 566
	i32 161, ; 567
	i32 277, ; 568
	i32 148, ; 569
	i32 104, ; 570
	i32 207, ; 571
	i32 89, ; 572
	i32 265, ; 573
	i32 60, ; 574
	i32 142, ; 575
	i32 100, ; 576
	i32 5, ; 577
	i32 13, ; 578
	i32 122, ; 579
	i32 135, ; 580
	i32 210, ; 581
	i32 28, ; 582
	i32 341, ; 583
	i32 72, ; 584
	i32 275, ; 585
	i32 24, ; 586
	i32 263, ; 587
	i32 175, ; 588
	i32 304, ; 589
	i32 301, ; 590
	i32 188, ; 591
	i32 358, ; 592
	i32 137, ; 593
	i32 256, ; 594
	i32 272, ; 595
	i32 168, ; 596
	i32 305, ; 597
	i32 337, ; 598
	i32 101, ; 599
	i32 123, ; 600
	i32 276, ; 601
	i32 226, ; 602
	i32 218, ; 603
	i32 221, ; 604
	i32 163, ; 605
	i32 167, ; 606
	i32 279, ; 607
	i32 39, ; 608
	i32 240, ; 609
	i32 345, ; 610
	i32 194, ; 611
	i32 17, ; 612
	i32 171, ; 613
	i32 358, ; 614
	i32 357, ; 615
	i32 137, ; 616
	i32 150, ; 617
	i32 268, ; 618
	i32 239, ; 619
	i32 155, ; 620
	i32 130, ; 621
	i32 19, ; 622
	i32 65, ; 623
	i32 188, ; 624
	i32 368, ; 625
	i32 147, ; 626
	i32 47, ; 627
	i32 365, ; 628
	i32 232, ; 629
	i32 254, ; 630
	i32 79, ; 631
	i32 173, ; 632
	i32 61, ; 633
	i32 106, ; 634
	i32 303, ; 635
	i32 258, ; 636
	i32 183, ; 637
	i32 49, ; 638
	i32 289, ; 639
	i32 362, ; 640
	i32 300, ; 641
	i32 14, ; 642
	i32 217, ; 643
	i32 68, ; 644
	i32 171, ; 645
	i32 264, ; 646
	i32 268, ; 647
	i32 187, ; 648
	i32 367, ; 649
	i32 78, ; 650
	i32 273, ; 651
	i32 108, ; 652
	i32 257, ; 653
	i32 220, ; 654
	i32 299, ; 655
	i32 67, ; 656
	i32 204, ; 657
	i32 63, ; 658
	i32 27, ; 659
	i32 160, ; 660
	i32 219, ; 661
	i32 236, ; 662
	i32 232, ; 663
	i32 266, ; 664
	i32 10, ; 665
	i32 240, ; 666
	i32 11, ; 667
	i32 78, ; 668
	i32 126, ; 669
	i32 83, ; 670
	i32 222, ; 671
	i32 66, ; 672
	i32 107, ; 673
	i32 65, ; 674
	i32 128, ; 675
	i32 122, ; 676
	i32 77, ; 677
	i32 314, ; 678
	i32 304, ; 679
	i32 366, ; 680
	i32 8, ; 681
	i32 272, ; 682
	i32 180, ; 683
	i32 231, ; 684
	i32 2, ; 685
	i32 44, ; 686
	i32 317, ; 687
	i32 156, ; 688
	i32 128, ; 689
	i32 302, ; 690
	i32 368, ; 691
	i32 23, ; 692
	i32 133, ; 693
	i32 231, ; 694
	i32 260, ; 695
	i32 291, ; 696
	i32 184, ; 697
	i32 178, ; 698
	i32 361, ; 699
	i32 343, ; 700
	i32 29, ; 701
	i32 259, ; 702
	i32 250, ; 703
	i32 62, ; 704
	i32 246, ; 705
	i32 242, ; 706
	i32 90, ; 707
	i32 87, ; 708
	i32 148, ; 709
	i32 230, ; 710
	i32 177, ; 711
	i32 186, ; 712
	i32 244, ; 713
	i32 36, ; 714
	i32 86, ; 715
	i32 280, ; 716
	i32 215, ; 717
	i32 356, ; 718
	i32 351, ; 719
	i32 221, ; 720
	i32 50, ; 721
	i32 6, ; 722
	i32 192, ; 723
	i32 90, ; 724
	i32 363, ; 725
	i32 21, ; 726
	i32 162, ; 727
	i32 96, ; 728
	i32 50, ; 729
	i32 113, ; 730
	i32 296, ; 731
	i32 130, ; 732
	i32 185, ; 733
	i32 76, ; 734
	i32 27, ; 735
	i32 273, ; 736
	i32 295, ; 737
	i32 7, ; 738
	i32 241, ; 739
	i32 110, ; 740
	i32 296, ; 741
	i32 227, ; 742
	i32 282 ; 743
], align 4

@marshal_methods_number_of_classes = dso_local local_unnamed_addr constant i32 0, align 4

@marshal_methods_class_cache = dso_local local_unnamed_addr global [0 x %struct.MarshalMethodsManagedClass] zeroinitializer, align 4

; Names of classes in which marshal methods reside
@mm_class_names = dso_local local_unnamed_addr constant [0 x ptr] zeroinitializer, align 4

@mm_method_names = dso_local local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		ptr @.MarshalMethodName.0_name; char* name
	} ; 0
], align 8

; get_function_pointer (uint32_t mono_image_index, uint32_t class_index, uint32_t method_token, void*& target_ptr)
@get_function_pointer = internal dso_local unnamed_addr global ptr null, align 4

; Functions

; Function attributes: "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nofree norecurse nosync nounwind "stack-protector-buffer-size"="8" uwtable willreturn
define void @xamarin_app_init(ptr nocapture noundef readnone %env, ptr noundef %fn) local_unnamed_addr #0
{
	%fnIsNull = icmp eq ptr %fn, null
	br i1 %fnIsNull, label %1, label %2

1: ; preds = %0
	%putsResult = call noundef i32 @puts(ptr @.str.0)
	call void @abort()
	unreachable 

2: ; preds = %1, %0
	store ptr %fn, ptr @get_function_pointer, align 4, !tbaa !3
	ret void
}

; Strings
@.str.0 = private unnamed_addr constant [40 x i8] c"get_function_pointer MUST be specified\0A\00", align 1

;MarshalMethodName
@.MarshalMethodName.0_name = private unnamed_addr constant [1 x i8] c"\00", align 1

; External functions

; Function attributes: "no-trapping-math"="true" noreturn nounwind "stack-protector-buffer-size"="8"
declare void @abort() local_unnamed_addr #2

; Function attributes: nofree nounwind
declare noundef i32 @puts(ptr noundef) local_unnamed_addr #1
attributes #0 = { "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nofree norecurse nosync nounwind "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-thumb-mode,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" uwtable willreturn }
attributes #1 = { nofree nounwind }
attributes #2 = { "no-trapping-math"="true" noreturn nounwind "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-thumb-mode,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" }

; Metadata
!llvm.module.flags = !{!0, !1, !7}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!llvm.ident = !{!2}
!2 = !{!"Xamarin.Android remotes/origin/release/8.0.2xx @ 96b6bb65e8736e45180905177aa343f0e1854ea3"}
!3 = !{!4, !4, i64 0}
!4 = !{!"any pointer", !5, i64 0}
!5 = !{!"omnipotent char", !6, i64 0}
!6 = !{!"Simple C++ TBAA"}
!7 = !{i32 1, !"min_enum_size", i32 4}
