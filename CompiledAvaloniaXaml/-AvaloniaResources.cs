using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Layout;
using Avalonia.Markup.Xaml;
using Avalonia.Markup.Xaml.MarkupExtensions;
using Avalonia.Markup.Xaml.XamlIl.Runtime;
using Avalonia.Media;
using Avalonia.Media.Immutable;
using Avalonia.Styling;

namespace CompiledAvaloniaXaml;

[EditorBrowsable(EditorBrowsableState.Never)]
[CompilerGenerated]
public class _0021AvaloniaResources
{
	[CompilerGenerated]
	internal class NamespaceInfo_003A_002FApp_002Eaxaml : IAvaloniaXamlIlXmlNamespaceInfoProvider
	{
		private IReadOnlyDictionary<string, IReadOnlyList<AvaloniaXamlIlXmlNamespaceInfo>> _xmlNamespaces;

		public static IAvaloniaXamlIlXmlNamespaceInfoProvider Singleton;

		public virtual IReadOnlyDictionary<string, IReadOnlyList<AvaloniaXamlIlXmlNamespaceInfo>> XmlNamespaces
		{
			get
			{
				if (_xmlNamespaces == null)
				{
					_xmlNamespaces = CreateNamespaces();
				}
				return _xmlNamespaces;
			}
		}

		private static AvaloniaXamlIlXmlNamespaceInfo CreateNamespaceInfo(string P_0, string P_1)
		{
			return new AvaloniaXamlIlXmlNamespaceInfo
			{
				ClrNamespace = P_0,
				ClrAssemblyName = P_1
			};
		}

		private static IReadOnlyDictionary<string, IReadOnlyList<AvaloniaXamlIlXmlNamespaceInfo>> CreateNamespaces()
		{
			return new Dictionary<string, IReadOnlyList<AvaloniaXamlIlXmlNamespaceInfo>>(3)
			{
				{
					"",
					new AvaloniaXamlIlXmlNamespaceInfo[33]
					{
						CreateNamespaceInfo("Avalonia", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.Animation", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.Animation.Easings", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.Controls", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.Data", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.Data.Converters", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.Input", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.Input.GestureRecognizers", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.Input.TextInput", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.Layout", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.LogicalTree", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.Media", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.Media.Imaging", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.Media.Transformation", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.Styling", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia", "Avalonia.Controls"),
						CreateNamespaceInfo("Avalonia.Automation", "Avalonia.Controls"),
						CreateNamespaceInfo("Avalonia.Controls", "Avalonia.Controls"),
						CreateNamespaceInfo("Avalonia.Controls.Embedding", "Avalonia.Controls"),
						CreateNamespaceInfo("Avalonia.Controls.Presenters", "Avalonia.Controls"),
						CreateNamespaceInfo("Avalonia.Controls.Primitives", "Avalonia.Controls"),
						CreateNamespaceInfo("Avalonia.Controls.Shapes", "Avalonia.Controls"),
						CreateNamespaceInfo("Avalonia.Controls.Templates", "Avalonia.Controls"),
						CreateNamespaceInfo("Avalonia.Controls.Notifications", "Avalonia.Controls"),
						CreateNamespaceInfo("Avalonia.Controls.Chrome", "Avalonia.Controls"),
						CreateNamespaceInfo("Avalonia.Controls.Documents", "Avalonia.Controls"),
						CreateNamespaceInfo("Avalonia.Fonts.Inter", "Avalonia.Fonts.Inter"),
						CreateNamespaceInfo("Avalonia.Data", "Avalonia.Markup"),
						CreateNamespaceInfo("Avalonia.Markup.Data", "Avalonia.Markup"),
						CreateNamespaceInfo("Avalonia.Markup.Xaml.MarkupExtensions", "Avalonia.Markup.Xaml"),
						CreateNamespaceInfo("Avalonia.Markup.Xaml.Styling", "Avalonia.Markup.Xaml"),
						CreateNamespaceInfo("Avalonia.Markup.Xaml.Templates", "Avalonia.Markup.Xaml"),
						CreateNamespaceInfo("Avalonia.Themes.Fluent", "Avalonia.Themes.Fluent")
					}
				},
				{
					"x",
					new AvaloniaXamlIlXmlNamespaceInfo[0]
				},
				{
					"vision",
					new AvaloniaXamlIlXmlNamespaceInfo[1] { CreateNamespaceInfo("Pfm.Services.Vision", null) }
				}
			};
		}

		static NamespaceInfo_003A_002FApp_002Eaxaml()
		{
			Singleton = new NamespaceInfo_003A_002FApp_002Eaxaml();
		}
	}

	[CompilerGenerated]
	internal class NamespaceInfo_003A_002FStyles_002FGlassTheme_002Eaxaml : IAvaloniaXamlIlXmlNamespaceInfoProvider
	{
		private IReadOnlyDictionary<string, IReadOnlyList<AvaloniaXamlIlXmlNamespaceInfo>> _xmlNamespaces;

		public static IAvaloniaXamlIlXmlNamespaceInfoProvider Singleton;

		public virtual IReadOnlyDictionary<string, IReadOnlyList<AvaloniaXamlIlXmlNamespaceInfo>> XmlNamespaces
		{
			get
			{
				if (_xmlNamespaces == null)
				{
					_xmlNamespaces = CreateNamespaces();
				}
				return _xmlNamespaces;
			}
		}

		private static AvaloniaXamlIlXmlNamespaceInfo CreateNamespaceInfo(string P_0, string P_1)
		{
			return new AvaloniaXamlIlXmlNamespaceInfo
			{
				ClrNamespace = P_0,
				ClrAssemblyName = P_1
			};
		}

		private static IReadOnlyDictionary<string, IReadOnlyList<AvaloniaXamlIlXmlNamespaceInfo>> CreateNamespaces()
		{
			return new Dictionary<string, IReadOnlyList<AvaloniaXamlIlXmlNamespaceInfo>>(2)
			{
				{
					"",
					new AvaloniaXamlIlXmlNamespaceInfo[33]
					{
						CreateNamespaceInfo("Avalonia", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.Animation", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.Animation.Easings", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.Controls", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.Data", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.Data.Converters", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.Input", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.Input.GestureRecognizers", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.Input.TextInput", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.Layout", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.LogicalTree", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.Media", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.Media.Imaging", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.Media.Transformation", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.Styling", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia", "Avalonia.Controls"),
						CreateNamespaceInfo("Avalonia.Automation", "Avalonia.Controls"),
						CreateNamespaceInfo("Avalonia.Controls", "Avalonia.Controls"),
						CreateNamespaceInfo("Avalonia.Controls.Embedding", "Avalonia.Controls"),
						CreateNamespaceInfo("Avalonia.Controls.Presenters", "Avalonia.Controls"),
						CreateNamespaceInfo("Avalonia.Controls.Primitives", "Avalonia.Controls"),
						CreateNamespaceInfo("Avalonia.Controls.Shapes", "Avalonia.Controls"),
						CreateNamespaceInfo("Avalonia.Controls.Templates", "Avalonia.Controls"),
						CreateNamespaceInfo("Avalonia.Controls.Notifications", "Avalonia.Controls"),
						CreateNamespaceInfo("Avalonia.Controls.Chrome", "Avalonia.Controls"),
						CreateNamespaceInfo("Avalonia.Controls.Documents", "Avalonia.Controls"),
						CreateNamespaceInfo("Avalonia.Fonts.Inter", "Avalonia.Fonts.Inter"),
						CreateNamespaceInfo("Avalonia.Data", "Avalonia.Markup"),
						CreateNamespaceInfo("Avalonia.Markup.Data", "Avalonia.Markup"),
						CreateNamespaceInfo("Avalonia.Markup.Xaml.MarkupExtensions", "Avalonia.Markup.Xaml"),
						CreateNamespaceInfo("Avalonia.Markup.Xaml.Styling", "Avalonia.Markup.Xaml"),
						CreateNamespaceInfo("Avalonia.Markup.Xaml.Templates", "Avalonia.Markup.Xaml"),
						CreateNamespaceInfo("Avalonia.Themes.Fluent", "Avalonia.Themes.Fluent")
					}
				},
				{
					"x",
					new AvaloniaXamlIlXmlNamespaceInfo[0]
				}
			};
		}

		static NamespaceInfo_003A_002FStyles_002FGlassTheme_002Eaxaml()
		{
			Singleton = new NamespaceInfo_003A_002FStyles_002FGlassTheme_002Eaxaml();
		}
	}

	[CompilerGenerated]
	private class XamlClosure_2
	{
		public static object Build_1(IServiceProvider P_0)
		{
			CompiledAvaloniaXaml.XamlIlContext.Context<Styles> context = CreateContext(P_0);
			return new SolidColorBrush
			{
				Color = Color.FromUInt32(4293849077u)
			};
		}

		public static CompiledAvaloniaXaml.XamlIlContext.Context<Styles> CreateContext(IServiceProvider P_0)
		{
			CompiledAvaloniaXaml.XamlIlContext.Context<Styles> context = new CompiledAvaloniaXaml.XamlIlContext.Context<Styles>(P_0, new object[1] { NamespaceInfo_003A_002FStyles_002FGlassTheme_002Eaxaml.Singleton }, "avares://PFMS/Styles/GlassTheme.axaml");
			if (P_0 != null)
			{
				object service = P_0.GetService(typeof(IRootObjectProvider));
				if (service != null)
				{
					service = ((IRootObjectProvider)service).RootObject;
					context.RootObject = (Styles)service;
				}
			}
			return context;
		}

		public static object Build_2(IServiceProvider P_0)
		{
			CompiledAvaloniaXaml.XamlIlContext.Context<Styles> context = CreateContext(P_0);
			return new SolidColorBrush
			{
				Color = Color.FromUInt32(4287993253u)
			};
		}

		public static object Build_3(IServiceProvider P_0)
		{
			CompiledAvaloniaXaml.XamlIlContext.Context<Styles> context = CreateContext(P_0);
			SolidColorBrush solidColorBrush;
			SolidColorBrush result = (solidColorBrush = new SolidColorBrush());
			context.PushParent(solidColorBrush);
			StaticResourceExtension staticResourceExtension = new StaticResourceExtension("BorderTint");
			context.ProvideTargetProperty = SolidColorBrush.ColorProperty;
			object? obj = staticResourceExtension.ProvideValue(context);
			context.ProvideTargetProperty = null;
			CompiledAvaloniaXaml.XamlDynamicSetters._003C_003EXamlDynamicSetter_1(solidColorBrush, obj);
			context.PopParent();
			return result;
		}
	}

	[CompilerGenerated]
	internal class NamespaceInfo_003A_002FViews_002FGameVisionOverlay_002Eaxaml : IAvaloniaXamlIlXmlNamespaceInfoProvider
	{
		private IReadOnlyDictionary<string, IReadOnlyList<AvaloniaXamlIlXmlNamespaceInfo>> _xmlNamespaces;

		public static IAvaloniaXamlIlXmlNamespaceInfoProvider Singleton;

		public virtual IReadOnlyDictionary<string, IReadOnlyList<AvaloniaXamlIlXmlNamespaceInfo>> XmlNamespaces
		{
			get
			{
				if (_xmlNamespaces == null)
				{
					_xmlNamespaces = CreateNamespaces();
				}
				return _xmlNamespaces;
			}
		}

		private static AvaloniaXamlIlXmlNamespaceInfo CreateNamespaceInfo(string P_0, string P_1)
		{
			return new AvaloniaXamlIlXmlNamespaceInfo
			{
				ClrNamespace = P_0,
				ClrAssemblyName = P_1
			};
		}

		private static IReadOnlyDictionary<string, IReadOnlyList<AvaloniaXamlIlXmlNamespaceInfo>> CreateNamespaces()
		{
			return new Dictionary<string, IReadOnlyList<AvaloniaXamlIlXmlNamespaceInfo>>(2)
			{
				{
					"",
					new AvaloniaXamlIlXmlNamespaceInfo[33]
					{
						CreateNamespaceInfo("Avalonia", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.Animation", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.Animation.Easings", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.Controls", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.Data", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.Data.Converters", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.Input", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.Input.GestureRecognizers", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.Input.TextInput", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.Layout", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.LogicalTree", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.Media", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.Media.Imaging", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.Media.Transformation", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.Styling", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia", "Avalonia.Controls"),
						CreateNamespaceInfo("Avalonia.Automation", "Avalonia.Controls"),
						CreateNamespaceInfo("Avalonia.Controls", "Avalonia.Controls"),
						CreateNamespaceInfo("Avalonia.Controls.Embedding", "Avalonia.Controls"),
						CreateNamespaceInfo("Avalonia.Controls.Presenters", "Avalonia.Controls"),
						CreateNamespaceInfo("Avalonia.Controls.Primitives", "Avalonia.Controls"),
						CreateNamespaceInfo("Avalonia.Controls.Shapes", "Avalonia.Controls"),
						CreateNamespaceInfo("Avalonia.Controls.Templates", "Avalonia.Controls"),
						CreateNamespaceInfo("Avalonia.Controls.Notifications", "Avalonia.Controls"),
						CreateNamespaceInfo("Avalonia.Controls.Chrome", "Avalonia.Controls"),
						CreateNamespaceInfo("Avalonia.Controls.Documents", "Avalonia.Controls"),
						CreateNamespaceInfo("Avalonia.Fonts.Inter", "Avalonia.Fonts.Inter"),
						CreateNamespaceInfo("Avalonia.Data", "Avalonia.Markup"),
						CreateNamespaceInfo("Avalonia.Markup.Data", "Avalonia.Markup"),
						CreateNamespaceInfo("Avalonia.Markup.Xaml.MarkupExtensions", "Avalonia.Markup.Xaml"),
						CreateNamespaceInfo("Avalonia.Markup.Xaml.Styling", "Avalonia.Markup.Xaml"),
						CreateNamespaceInfo("Avalonia.Markup.Xaml.Templates", "Avalonia.Markup.Xaml"),
						CreateNamespaceInfo("Avalonia.Themes.Fluent", "Avalonia.Themes.Fluent")
					}
				},
				{
					"x",
					new AvaloniaXamlIlXmlNamespaceInfo[0]
				}
			};
		}

		static NamespaceInfo_003A_002FViews_002FGameVisionOverlay_002Eaxaml()
		{
			Singleton = new NamespaceInfo_003A_002FViews_002FGameVisionOverlay_002Eaxaml();
		}
	}

	[CompilerGenerated]
	internal class NamespaceInfo_003A_002FViews_002FHelpWindow_002Eaxaml : IAvaloniaXamlIlXmlNamespaceInfoProvider
	{
		private IReadOnlyDictionary<string, IReadOnlyList<AvaloniaXamlIlXmlNamespaceInfo>> _xmlNamespaces;

		public static IAvaloniaXamlIlXmlNamespaceInfoProvider Singleton;

		public virtual IReadOnlyDictionary<string, IReadOnlyList<AvaloniaXamlIlXmlNamespaceInfo>> XmlNamespaces
		{
			get
			{
				if (_xmlNamespaces == null)
				{
					_xmlNamespaces = CreateNamespaces();
				}
				return _xmlNamespaces;
			}
		}

		private static AvaloniaXamlIlXmlNamespaceInfo CreateNamespaceInfo(string P_0, string P_1)
		{
			return new AvaloniaXamlIlXmlNamespaceInfo
			{
				ClrNamespace = P_0,
				ClrAssemblyName = P_1
			};
		}

		private static IReadOnlyDictionary<string, IReadOnlyList<AvaloniaXamlIlXmlNamespaceInfo>> CreateNamespaces()
		{
			return new Dictionary<string, IReadOnlyList<AvaloniaXamlIlXmlNamespaceInfo>>(2)
			{
				{
					"",
					new AvaloniaXamlIlXmlNamespaceInfo[33]
					{
						CreateNamespaceInfo("Avalonia", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.Animation", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.Animation.Easings", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.Controls", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.Data", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.Data.Converters", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.Input", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.Input.GestureRecognizers", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.Input.TextInput", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.Layout", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.LogicalTree", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.Media", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.Media.Imaging", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.Media.Transformation", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.Styling", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia", "Avalonia.Controls"),
						CreateNamespaceInfo("Avalonia.Automation", "Avalonia.Controls"),
						CreateNamespaceInfo("Avalonia.Controls", "Avalonia.Controls"),
						CreateNamespaceInfo("Avalonia.Controls.Embedding", "Avalonia.Controls"),
						CreateNamespaceInfo("Avalonia.Controls.Presenters", "Avalonia.Controls"),
						CreateNamespaceInfo("Avalonia.Controls.Primitives", "Avalonia.Controls"),
						CreateNamespaceInfo("Avalonia.Controls.Shapes", "Avalonia.Controls"),
						CreateNamespaceInfo("Avalonia.Controls.Templates", "Avalonia.Controls"),
						CreateNamespaceInfo("Avalonia.Controls.Notifications", "Avalonia.Controls"),
						CreateNamespaceInfo("Avalonia.Controls.Chrome", "Avalonia.Controls"),
						CreateNamespaceInfo("Avalonia.Controls.Documents", "Avalonia.Controls"),
						CreateNamespaceInfo("Avalonia.Fonts.Inter", "Avalonia.Fonts.Inter"),
						CreateNamespaceInfo("Avalonia.Data", "Avalonia.Markup"),
						CreateNamespaceInfo("Avalonia.Markup.Data", "Avalonia.Markup"),
						CreateNamespaceInfo("Avalonia.Markup.Xaml.MarkupExtensions", "Avalonia.Markup.Xaml"),
						CreateNamespaceInfo("Avalonia.Markup.Xaml.Styling", "Avalonia.Markup.Xaml"),
						CreateNamespaceInfo("Avalonia.Markup.Xaml.Templates", "Avalonia.Markup.Xaml"),
						CreateNamespaceInfo("Avalonia.Themes.Fluent", "Avalonia.Themes.Fluent")
					}
				},
				{
					"x",
					new AvaloniaXamlIlXmlNamespaceInfo[0]
				}
			};
		}

		static NamespaceInfo_003A_002FViews_002FHelpWindow_002Eaxaml()
		{
			Singleton = new NamespaceInfo_003A_002FViews_002FHelpWindow_002Eaxaml();
		}
	}

	[CompilerGenerated]
	internal class NamespaceInfo_003A_002FViews_002FMainWindow_002Eaxaml : IAvaloniaXamlIlXmlNamespaceInfoProvider
	{
		private IReadOnlyDictionary<string, IReadOnlyList<AvaloniaXamlIlXmlNamespaceInfo>> _xmlNamespaces;

		public static IAvaloniaXamlIlXmlNamespaceInfoProvider Singleton;

		public virtual IReadOnlyDictionary<string, IReadOnlyList<AvaloniaXamlIlXmlNamespaceInfo>> XmlNamespaces
		{
			get
			{
				if (_xmlNamespaces == null)
				{
					_xmlNamespaces = CreateNamespaces();
				}
				return _xmlNamespaces;
			}
		}

		private static AvaloniaXamlIlXmlNamespaceInfo CreateNamespaceInfo(string P_0, string P_1)
		{
			return new AvaloniaXamlIlXmlNamespaceInfo
			{
				ClrNamespace = P_0,
				ClrAssemblyName = P_1
			};
		}

		private static IReadOnlyDictionary<string, IReadOnlyList<AvaloniaXamlIlXmlNamespaceInfo>> CreateNamespaces()
		{
			return new Dictionary<string, IReadOnlyList<AvaloniaXamlIlXmlNamespaceInfo>>(5)
			{
				{
					"",
					new AvaloniaXamlIlXmlNamespaceInfo[33]
					{
						CreateNamespaceInfo("Avalonia", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.Animation", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.Animation.Easings", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.Controls", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.Data", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.Data.Converters", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.Input", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.Input.GestureRecognizers", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.Input.TextInput", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.Layout", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.LogicalTree", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.Media", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.Media.Imaging", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.Media.Transformation", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.Styling", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia", "Avalonia.Controls"),
						CreateNamespaceInfo("Avalonia.Automation", "Avalonia.Controls"),
						CreateNamespaceInfo("Avalonia.Controls", "Avalonia.Controls"),
						CreateNamespaceInfo("Avalonia.Controls.Embedding", "Avalonia.Controls"),
						CreateNamespaceInfo("Avalonia.Controls.Presenters", "Avalonia.Controls"),
						CreateNamespaceInfo("Avalonia.Controls.Primitives", "Avalonia.Controls"),
						CreateNamespaceInfo("Avalonia.Controls.Shapes", "Avalonia.Controls"),
						CreateNamespaceInfo("Avalonia.Controls.Templates", "Avalonia.Controls"),
						CreateNamespaceInfo("Avalonia.Controls.Notifications", "Avalonia.Controls"),
						CreateNamespaceInfo("Avalonia.Controls.Chrome", "Avalonia.Controls"),
						CreateNamespaceInfo("Avalonia.Controls.Documents", "Avalonia.Controls"),
						CreateNamespaceInfo("Avalonia.Fonts.Inter", "Avalonia.Fonts.Inter"),
						CreateNamespaceInfo("Avalonia.Data", "Avalonia.Markup"),
						CreateNamespaceInfo("Avalonia.Markup.Data", "Avalonia.Markup"),
						CreateNamespaceInfo("Avalonia.Markup.Xaml.MarkupExtensions", "Avalonia.Markup.Xaml"),
						CreateNamespaceInfo("Avalonia.Markup.Xaml.Styling", "Avalonia.Markup.Xaml"),
						CreateNamespaceInfo("Avalonia.Markup.Xaml.Templates", "Avalonia.Markup.Xaml"),
						CreateNamespaceInfo("Avalonia.Themes.Fluent", "Avalonia.Themes.Fluent")
					}
				},
				{
					"x",
					new AvaloniaXamlIlXmlNamespaceInfo[0]
				},
				{
					"vm",
					new AvaloniaXamlIlXmlNamespaceInfo[1] { CreateNamespaceInfo("Pfm.ViewModels", null) }
				},
				{
					"d",
					new AvaloniaXamlIlXmlNamespaceInfo[0]
				},
				{
					"mc",
					new AvaloniaXamlIlXmlNamespaceInfo[0]
				}
			};
		}

		static NamespaceInfo_003A_002FViews_002FMainWindow_002Eaxaml()
		{
			Singleton = new NamespaceInfo_003A_002FViews_002FMainWindow_002Eaxaml();
		}
	}

	[CompilerGenerated]
	internal class NamespaceInfo_003A_002FViews_002FScreenRegionSelectionWindow_002Eaxaml : IAvaloniaXamlIlXmlNamespaceInfoProvider
	{
		private IReadOnlyDictionary<string, IReadOnlyList<AvaloniaXamlIlXmlNamespaceInfo>> _xmlNamespaces;

		public static IAvaloniaXamlIlXmlNamespaceInfoProvider Singleton;

		public virtual IReadOnlyDictionary<string, IReadOnlyList<AvaloniaXamlIlXmlNamespaceInfo>> XmlNamespaces
		{
			get
			{
				if (_xmlNamespaces == null)
				{
					_xmlNamespaces = CreateNamespaces();
				}
				return _xmlNamespaces;
			}
		}

		private static AvaloniaXamlIlXmlNamespaceInfo CreateNamespaceInfo(string P_0, string P_1)
		{
			return new AvaloniaXamlIlXmlNamespaceInfo
			{
				ClrNamespace = P_0,
				ClrAssemblyName = P_1
			};
		}

		private static IReadOnlyDictionary<string, IReadOnlyList<AvaloniaXamlIlXmlNamespaceInfo>> CreateNamespaces()
		{
			return new Dictionary<string, IReadOnlyList<AvaloniaXamlIlXmlNamespaceInfo>>(2)
			{
				{
					"",
					new AvaloniaXamlIlXmlNamespaceInfo[33]
					{
						CreateNamespaceInfo("Avalonia", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.Animation", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.Animation.Easings", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.Controls", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.Data", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.Data.Converters", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.Input", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.Input.GestureRecognizers", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.Input.TextInput", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.Layout", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.LogicalTree", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.Media", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.Media.Imaging", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.Media.Transformation", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia.Styling", "Avalonia.Base"),
						CreateNamespaceInfo("Avalonia", "Avalonia.Controls"),
						CreateNamespaceInfo("Avalonia.Automation", "Avalonia.Controls"),
						CreateNamespaceInfo("Avalonia.Controls", "Avalonia.Controls"),
						CreateNamespaceInfo("Avalonia.Controls.Embedding", "Avalonia.Controls"),
						CreateNamespaceInfo("Avalonia.Controls.Presenters", "Avalonia.Controls"),
						CreateNamespaceInfo("Avalonia.Controls.Primitives", "Avalonia.Controls"),
						CreateNamespaceInfo("Avalonia.Controls.Shapes", "Avalonia.Controls"),
						CreateNamespaceInfo("Avalonia.Controls.Templates", "Avalonia.Controls"),
						CreateNamespaceInfo("Avalonia.Controls.Notifications", "Avalonia.Controls"),
						CreateNamespaceInfo("Avalonia.Controls.Chrome", "Avalonia.Controls"),
						CreateNamespaceInfo("Avalonia.Controls.Documents", "Avalonia.Controls"),
						CreateNamespaceInfo("Avalonia.Fonts.Inter", "Avalonia.Fonts.Inter"),
						CreateNamespaceInfo("Avalonia.Data", "Avalonia.Markup"),
						CreateNamespaceInfo("Avalonia.Markup.Data", "Avalonia.Markup"),
						CreateNamespaceInfo("Avalonia.Markup.Xaml.MarkupExtensions", "Avalonia.Markup.Xaml"),
						CreateNamespaceInfo("Avalonia.Markup.Xaml.Styling", "Avalonia.Markup.Xaml"),
						CreateNamespaceInfo("Avalonia.Markup.Xaml.Templates", "Avalonia.Markup.Xaml"),
						CreateNamespaceInfo("Avalonia.Themes.Fluent", "Avalonia.Themes.Fluent")
					}
				},
				{
					"x",
					new AvaloniaXamlIlXmlNamespaceInfo[0]
				}
			};
		}

		static NamespaceInfo_003A_002FViews_002FScreenRegionSelectionWindow_002Eaxaml()
		{
			Singleton = new NamespaceInfo_003A_002FViews_002FScreenRegionSelectionWindow_002Eaxaml();
		}
	}

	public unsafe static void Populate_003A_002FStyles_002FGlassTheme_002Eaxaml(IServiceProvider P_0, Styles P_1)
	{
		CompiledAvaloniaXaml.XamlIlContext.Context<Styles> context = new CompiledAvaloniaXaml.XamlIlContext.Context<Styles>(P_0, new object[1] { NamespaceInfo_003A_002FStyles_002FGlassTheme_002Eaxaml.Singleton }, "avares://PFMS/Styles/GlassTheme.axaml")
		{
			RootObject = P_1,
			IntermediateRoot = P_1
		};
		Styles styles2;
		Styles styles = (styles2 = P_1);
		context.PushParent(styles2);
		if (styles2.Resources is ResourceDictionary resourceDictionary)
		{
			resourceDictionary.EnsureCapacity(resourceDictionary.Count + 6);
		}
		styles2.Resources.Add("ShellTint", Color.FromUInt32(3591376920u));
		styles2.Resources.Add("CardTint", Color.FromUInt32(1797004328u));
		styles2.Resources.Add("BorderTint", Color.FromUInt32(1127560517u));
		((ResourceDictionary)styles2.Resources).AddDeferred((object)"PrimaryTextBrush", XamlIlRuntimeHelpers.DeferredTransformationFactoryV3<object>((nint)(delegate*<IServiceProvider, object>)(&XamlClosure_2.Build_1), context));
		((ResourceDictionary)styles2.Resources).AddDeferred((object)"SecondaryTextBrush", XamlIlRuntimeHelpers.DeferredTransformationFactoryV3<object>((nint)(delegate*<IServiceProvider, object>)(&XamlClosure_2.Build_2), context));
		((ResourceDictionary)styles2.Resources).AddDeferred((object)"GlassBorderBrush", XamlIlRuntimeHelpers.DeferredTransformationFactoryV3<object>((nint)(delegate*<IServiceProvider, object>)(&XamlClosure_2.Build_3), context));
		Style style;
		Style item = (style = new Style());
		context.PushParent(style);
		Style style2 = style;
		style2.Selector = ((Selector?)null).OfType(typeof(Window));
		Setter setter = new Setter();
		setter.Property = TemplatedControl.FontFamilyProperty;
		setter.Value = new FontFamily(((IUriContext)context).BaseUri, "avares://Avalonia.Fonts.Inter/Assets#Inter");
		style2.Add(setter);
		Setter setter3;
		Setter setter2 = (setter3 = new Setter());
		context.PushParent(setter3);
		Setter setter4 = setter3;
		setter4.Property = TemplatedControl.ForegroundProperty;
		StaticResourceExtension staticResourceExtension = new StaticResourceExtension("PrimaryTextBrush");
		context.ProvideTargetProperty = CompiledAvaloniaXaml.XamlIlHelpers.Avalonia_002EStyling_002ESetter_002CAvalonia_002EBase_002EValue_0021Property();
		object? value = staticResourceExtension.ProvideValue(context);
		context.ProvideTargetProperty = null;
		setter4.Value = value;
		context.PopParent();
		style2.Add(setter2);
		context.PopParent();
		styles2.Add(item);
		Style item2 = (style = new Style());
		context.PushParent(style);
		Style style3 = style;
		style3.Selector = ((Selector?)null).OfType(typeof(Border)).Class("glass-shell");
		Setter setter5 = (setter3 = new Setter());
		context.PushParent(setter3);
		Setter setter6 = setter3;
		setter6.Property = Border.BackgroundProperty;
		StaticResourceExtension staticResourceExtension2 = new StaticResourceExtension("ShellTint");
		context.ProvideTargetProperty = CompiledAvaloniaXaml.XamlIlHelpers.Avalonia_002EStyling_002ESetter_002CAvalonia_002EBase_002EValue_0021Property();
		object? value2 = staticResourceExtension2.ProvideValue(context);
		context.ProvideTargetProperty = null;
		setter6.Value = value2;
		context.PopParent();
		style3.Add(setter5);
		Setter setter7 = (setter3 = new Setter());
		context.PushParent(setter3);
		Setter setter8 = setter3;
		setter8.Property = Border.BorderBrushProperty;
		StaticResourceExtension staticResourceExtension3 = new StaticResourceExtension("GlassBorderBrush");
		context.ProvideTargetProperty = CompiledAvaloniaXaml.XamlIlHelpers.Avalonia_002EStyling_002ESetter_002CAvalonia_002EBase_002EValue_0021Property();
		object? value3 = staticResourceExtension3.ProvideValue(context);
		context.ProvideTargetProperty = null;
		setter8.Value = value3;
		context.PopParent();
		style3.Add(setter7);
		Setter setter9 = new Setter();
		setter9.Property = Border.BorderThicknessProperty;
		setter9.Value = new Thickness(1.0, 1.0, 1.0, 1.0);
		style3.Add(setter9);
		Setter setter10 = new Setter();
		setter10.Property = Border.BoxShadowProperty;
		setter10.Value = BoxShadows.Parse("0 24 80 0 #5000000A");
		style3.Add(setter10);
		context.PopParent();
		styles2.Add(item2);
		Style style4 = new Style();
		style4.Selector = ((Selector?)null).OfType(typeof(Border)).Class("sidebar");
		Setter setter11 = new Setter();
		setter11.Property = Border.BackgroundProperty;
		setter11.Value = new ImmutableSolidColorBrush(2517964064u);
		style4.Add(setter11);
		Setter setter12 = new Setter();
		setter12.Property = Border.BorderBrushProperty;
		setter12.Value = new ImmutableSolidColorBrush(807938104u);
		style4.Add(setter12);
		Setter setter13 = new Setter();
		setter13.Property = Border.BorderThicknessProperty;
		setter13.Value = new Thickness(0.0, 0.0, 1.0, 0.0);
		style4.Add(setter13);
		styles2.Add(style4);
		Style style5 = new Style();
		style5.Selector = ((Selector?)null).OfType(typeof(Border)).Class("brand-mark");
		Setter setter14 = new Setter();
		setter14.Property = Border.BackgroundProperty;
		setter14.Value = new ImmutableSolidColorBrush(673720360u);
		style5.Add(setter14);
		Setter setter15 = new Setter();
		setter15.Property = Border.BorderBrushProperty;
		setter15.Value = new ImmutableSolidColorBrush(1919247738u);
		style5.Add(setter15);
		Setter setter16 = new Setter();
		setter16.Property = Border.BorderThicknessProperty;
		setter16.Value = new Thickness(1.0, 1.0, 1.0, 1.0);
		style5.Add(setter16);
		Setter setter17 = new Setter();
		setter17.Property = Border.CornerRadiusProperty;
		setter17.Value = new CornerRadius(13.0, 13.0, 13.0, 13.0);
		style5.Add(setter17);
		styles2.Add(style5);
		Style style6 = new Style();
		style6.Selector = ((Selector?)null).OfType(typeof(TextBlock)).Class("brand-mark-text");
		Setter setter18 = new Setter();
		setter18.Property = TextBlock.FontWeightProperty;
		setter18.Value = FontWeight.Bold;
		style6.Add(setter18);
		Setter setter19 = new Setter();
		setter19.Property = TextBlock.FontSizeProperty;
		setter19.Value = 13.0;
		style6.Add(setter19);
		Setter setter20 = new Setter();
		setter20.Property = Layoutable.HorizontalAlignmentProperty;
		setter20.Value = HorizontalAlignment.Center;
		style6.Add(setter20);
		Setter setter21 = new Setter();
		setter21.Property = Layoutable.VerticalAlignmentProperty;
		setter21.Value = VerticalAlignment.Center;
		style6.Add(setter21);
		styles2.Add(style6);
		Style style7 = new Style();
		style7.Selector = ((Selector?)null).OfType(typeof(TextBlock)).Class("brand-title");
		Setter setter22 = new Setter();
		setter22.Property = TextBlock.FontSizeProperty;
		setter22.Value = 25.0;
		style7.Add(setter22);
		Setter setter23 = new Setter();
		setter23.Property = TextBlock.FontWeightProperty;
		setter23.Value = FontWeight.DemiBold;
		style7.Add(setter23);
		styles2.Add(style7);
		Style style8 = new Style();
		style8.Selector = ((Selector?)null).OfType(typeof(TextBlock)).Class("eyebrow");
		Setter setter24 = new Setter();
		setter24.Property = TextBlock.FontSizeProperty;
		setter24.Value = 10.0;
		style8.Add(setter24);
		Setter setter25 = new Setter();
		setter25.Property = TextBlock.FontWeightProperty;
		setter25.Value = FontWeight.DemiBold;
		style8.Add(setter25);
		Setter setter26 = new Setter();
		setter26.Property = TextBlock.ForegroundProperty;
		setter26.Value = new ImmutableSolidColorBrush(4286216842u);
		style8.Add(setter26);
		Setter setter27 = new Setter();
		setter27.Property = TextBlock.LetterSpacingProperty;
		setter27.Value = 1.5;
		style8.Add(setter27);
		styles2.Add(style8);
		Style style9 = new Style();
		style9.Selector = ((Selector?)null).OfType(typeof(TextBlock)).Class("accent");
		Setter setter28 = new Setter();
		setter28.Property = TextBlock.ForegroundProperty;
		setter28.Value = new ImmutableSolidColorBrush(4291611869u);
		style9.Add(setter28);
		styles2.Add(style9);
		Style style10 = new Style();
		style10.Selector = ((Selector?)null).OfType(typeof(TextBlock)).Class("nav-caption");
		Setter setter29 = new Setter();
		setter29.Property = TextBlock.FontSizeProperty;
		setter29.Value = 10.0;
		style10.Add(setter29);
		Setter setter30 = new Setter();
		setter30.Property = TextBlock.FontWeightProperty;
		setter30.Value = FontWeight.DemiBold;
		style10.Add(setter30);
		Setter setter31 = new Setter();
		setter31.Property = TextBlock.ForegroundProperty;
		setter31.Value = new ImmutableSolidColorBrush(4285164154u);
		style10.Add(setter31);
		Setter setter32 = new Setter();
		setter32.Property = TextBlock.LetterSpacingProperty;
		setter32.Value = 1.2;
		style10.Add(setter32);
		Setter setter33 = new Setter();
		setter33.Property = Layoutable.MarginProperty;
		setter33.Value = new Thickness(12.0, 0.0, 0.0, 4.0);
		style10.Add(setter33);
		styles2.Add(style10);
		Style style11 = new Style();
		style11.Selector = ((Selector?)null).OfType(typeof(Button)).Class("nav-item");
		Setter setter34 = new Setter();
		setter34.Property = TemplatedControl.BackgroundProperty;
		setter34.Value = new ImmutableSolidColorBrush(16777215u);
		style11.Add(setter34);
		Setter setter35 = new Setter();
		setter35.Property = TemplatedControl.ForegroundProperty;
		setter35.Value = new ImmutableSolidColorBrush(4288716976u);
		style11.Add(setter35);
		Setter setter36 = new Setter();
		setter36.Property = TemplatedControl.PaddingProperty;
		setter36.Value = new Thickness(12.0, 11.0, 12.0, 11.0);
		style11.Add(setter36);
		Setter setter37 = new Setter();
		setter37.Property = ContentControl.HorizontalContentAlignmentProperty;
		setter37.Value = HorizontalAlignment.Left;
		style11.Add(setter37);
		Setter setter38 = new Setter();
		setter38.Property = TemplatedControl.CornerRadiusProperty;
		setter38.Value = new CornerRadius(10.0, 10.0, 10.0, 10.0);
		style11.Add(setter38);
		Setter setter39 = new Setter();
		setter39.Property = TemplatedControl.FontSizeProperty;
		setter39.Value = 13.0;
		style11.Add(setter39);
		styles2.Add(style11);
		Style style12 = new Style();
		style12.Selector = ((Selector?)null).OfType(typeof(Button)).Class("nav-item").Class(":pointerover");
		Setter setter40 = new Setter();
		setter40.Property = TemplatedControl.BackgroundProperty;
		setter40.Value = new ImmutableSolidColorBrush(421141034u);
		style12.Add(setter40);
		styles2.Add(style12);
		Style style13 = new Style();
		style13.Selector = ((Selector?)null).OfType(typeof(Button)).Class("nav-item").Class("selected");
		Setter setter41 = new Setter();
		setter41.Property = TemplatedControl.BackgroundProperty;
		setter41.Value = new ImmutableSolidColorBrush(1244672064u);
		style13.Add(setter41);
		Setter setter42 = new Setter();
		setter42.Property = TemplatedControl.ForegroundProperty;
		setter42.Value = new ImmutableSolidColorBrush(uint.MaxValue);
		style13.Add(setter42);
		styles2.Add(style13);
		Style style14 = new Style();
		style14.Selector = ((Selector?)null).OfType(typeof(TextBlock)).Class("nav-icon");
		Setter setter43 = new Setter();
		setter43.Property = TextBlock.FontSizeProperty;
		setter43.Value = 16.0;
		style14.Add(setter43);
		Setter setter44 = new Setter();
		setter44.Property = Layoutable.WidthProperty;
		setter44.Value = 16.0;
		style14.Add(setter44);
		styles2.Add(style14);
		Style style15 = new Style();
		style15.Selector = ((Selector?)null).OfType(typeof(Border)).Class("status-card");
		Setter setter45 = new Setter();
		setter45.Property = Border.BackgroundProperty;
		setter45.Value = new ImmutableSolidColorBrush(1192892970u);
		style15.Add(setter45);
		Setter setter46 = new Setter();
		setter46.Property = Border.BorderBrushProperty;
		setter46.Value = new ImmutableSolidColorBrush(674246722u);
		style15.Add(setter46);
		Setter setter47 = new Setter();
		setter47.Property = Border.BorderThicknessProperty;
		setter47.Value = new Thickness(1.0, 1.0, 1.0, 1.0);
		style15.Add(setter47);
		Setter setter48 = new Setter();
		setter48.Property = Border.CornerRadiusProperty;
		setter48.Value = new CornerRadius(12.0, 12.0, 12.0, 12.0);
		style15.Add(setter48);
		styles2.Add(style15);
		Style style16 = new Style();
		style16.Selector = ((Selector?)null).OfType(typeof(TextBlock)).Class("status-title");
		Setter setter49 = new Setter();
		setter49.Property = TextBlock.FontSizeProperty;
		setter49.Value = 11.0;
		style16.Add(setter49);
		Setter setter50 = new Setter();
		setter50.Property = TextBlock.FontWeightProperty;
		setter50.Value = FontWeight.DemiBold;
		style16.Add(setter50);
		styles2.Add(style16);
		Style style17 = new Style();
		style17.Selector = ((Selector?)null).OfType(typeof(TextBlock)).Class("status-copy");
		Setter setter51 = new Setter();
		setter51.Property = TextBlock.FontSizeProperty;
		setter51.Value = 10.0;
		style17.Add(setter51);
		Setter setter52 = new Setter();
		setter52.Property = TextBlock.ForegroundProperty;
		setter52.Value = new ImmutableSolidColorBrush(4286216842u);
		style17.Add(setter52);
		styles2.Add(style17);
		Style style18 = new Style();
		style18.Selector = ((Selector?)null).OfType(typeof(TextBlock)).Class("page-title");
		Setter setter53 = new Setter();
		setter53.Property = TextBlock.FontSizeProperty;
		setter53.Value = 29.0;
		style18.Add(setter53);
		Setter setter54 = new Setter();
		setter54.Property = TextBlock.FontWeightProperty;
		setter54.Value = FontWeight.DemiBold;
		style18.Add(setter54);
		Setter setter55 = new Setter();
		setter55.Property = TextBlock.LetterSpacingProperty;
		setter55.Value = -0.8;
		style18.Add(setter55);
		styles2.Add(style18);
		Style item3 = (style = new Style());
		context.PushParent(style);
		Style style19 = style;
		style19.Selector = ((Selector?)null).OfType(typeof(TextBlock)).Class("page-subtitle");
		Setter setter56 = new Setter();
		setter56.Property = TextBlock.FontSizeProperty;
		setter56.Value = 13.0;
		style19.Add(setter56);
		Setter setter57 = (setter3 = new Setter());
		context.PushParent(setter3);
		Setter setter58 = setter3;
		setter58.Property = TextBlock.ForegroundProperty;
		StaticResourceExtension staticResourceExtension4 = new StaticResourceExtension("SecondaryTextBrush");
		context.ProvideTargetProperty = CompiledAvaloniaXaml.XamlIlHelpers.Avalonia_002EStyling_002ESetter_002CAvalonia_002EBase_002EValue_0021Property();
		object? value4 = staticResourceExtension4.ProvideValue(context);
		context.ProvideTargetProperty = null;
		setter58.Value = value4;
		context.PopParent();
		style19.Add(setter57);
		context.PopParent();
		styles2.Add(item3);
		Style style20 = new Style();
		style20.Selector = ((Selector?)null).OfType(typeof(Button)).Class("primary-button");
		Setter setter59 = new Setter();
		setter59.Property = TemplatedControl.BackgroundProperty;
		setter59.Value = new ImmutableSolidColorBrush(4293848821u);
		style20.Add(setter59);
		Setter setter60 = new Setter();
		setter60.Property = TemplatedControl.ForegroundProperty;
		setter60.Value = new ImmutableSolidColorBrush(4278848018u);
		style20.Add(setter60);
		Setter setter61 = new Setter();
		setter61.Property = TemplatedControl.PaddingProperty;
		setter61.Value = new Thickness(17.0, 11.0, 17.0, 11.0);
		style20.Add(setter61);
		Setter setter62 = new Setter();
		setter62.Property = TemplatedControl.CornerRadiusProperty;
		setter62.Value = new CornerRadius(10.0, 10.0, 10.0, 10.0);
		style20.Add(setter62);
		Setter setter63 = new Setter();
		setter63.Property = TemplatedControl.FontWeightProperty;
		setter63.Value = FontWeight.DemiBold;
		style20.Add(setter63);
		Setter setter64 = new Setter();
		setter64.Property = TemplatedControl.FontSizeProperty;
		setter64.Value = 12.0;
		style20.Add(setter64);
		styles2.Add(style20);
		Style style21 = new Style();
		style21.Selector = ((Selector?)null).OfType(typeof(Button)).Class("primary-button").Class(":pointerover");
		Setter setter65 = new Setter();
		setter65.Property = TemplatedControl.BackgroundProperty;
		setter65.Value = new ImmutableSolidColorBrush(uint.MaxValue);
		style21.Add(setter65);
		styles2.Add(style21);
		Style style22 = new Style();
		style22.Selector = ((Selector?)null).OfType(typeof(Border)).Class("insight-banner");
		Setter setter66 = new Setter();
		setter66.Property = Border.BackgroundProperty;
		setter66.Value = new ImmutableSolidColorBrush(807017002u);
		style22.Add(setter66);
		Setter setter67 = new Setter();
		setter67.Property = Border.BorderBrushProperty;
		setter67.Value = new ImmutableSolidColorBrush(995645546u);
		style22.Add(setter67);
		Setter setter68 = new Setter();
		setter68.Property = Border.BorderThicknessProperty;
		setter68.Value = new Thickness(1.0, 1.0, 1.0, 1.0);
		style22.Add(setter68);
		Setter setter69 = new Setter();
		setter69.Property = Border.CornerRadiusProperty;
		setter69.Value = new CornerRadius(13.0, 13.0, 13.0, 13.0);
		style22.Add(setter69);
		styles2.Add(style22);
		Style style23 = new Style();
		style23.Selector = ((Selector?)null).OfType(typeof(Border)).Class("insight-icon");
		Setter setter70 = new Setter();
		setter70.Property = Border.BackgroundProperty;
		setter70.Value = new ImmutableSolidColorBrush(891297840u);
		style23.Add(setter70);
		Setter setter71 = new Setter();
		setter71.Property = Border.CornerRadiusProperty;
		setter71.Value = new CornerRadius(9.0, 9.0, 9.0, 9.0);
		style23.Add(setter71);
		styles2.Add(style23);
		Style style24 = new Style();
		style24.Selector = ((Selector?)null).OfType(typeof(TextBlock)).Class("banner-title");
		Setter setter72 = new Setter();
		setter72.Property = TextBlock.FontSizeProperty;
		setter72.Value = 12.0;
		style24.Add(setter72);
		Setter setter73 = new Setter();
		setter73.Property = TextBlock.FontWeightProperty;
		setter73.Value = FontWeight.DemiBold;
		style24.Add(setter73);
		styles2.Add(style24);
		Style style25 = new Style();
		style25.Selector = ((Selector?)null).OfType(typeof(TextBlock)).Class("banner-copy");
		Setter setter74 = new Setter();
		setter74.Property = TextBlock.FontSizeProperty;
		setter74.Value = 11.0;
		style25.Add(setter74);
		Setter setter75 = new Setter();
		setter75.Property = TextBlock.ForegroundProperty;
		setter75.Value = new ImmutableSolidColorBrush(4287269530u);
		style25.Add(setter75);
		styles2.Add(style25);
		Style style26 = new Style();
		style26.Selector = ((Selector?)null).OfType(typeof(TextBlock)).Class("mechanic-badge");
		Setter setter76 = new Setter();
		setter76.Property = TextBlock.BackgroundProperty;
		setter76.Value = new ImmutableSolidColorBrush(588913194u);
		style26.Add(setter76);
		Setter setter77 = new Setter();
		setter77.Property = TextBlock.ForegroundProperty;
		setter77.Value = new ImmutableSolidColorBrush(4289769664u);
		style26.Add(setter77);
		Setter setter78 = new Setter();
		setter78.Property = TextBlock.PaddingProperty;
		setter78.Value = new Thickness(9.0, 5.0, 9.0, 5.0);
		style26.Add(setter78);
		Setter setter79 = new Setter();
		setter79.Property = TextBlock.FontSizeProperty;
		setter79.Value = 10.0;
		style26.Add(setter79);
		styles2.Add(style26);
		Style style27 = new Style();
		style27.Selector = ((Selector?)null).OfType(typeof(TextBlock)).Class("section-title");
		Setter setter80 = new Setter();
		setter80.Property = TextBlock.FontSizeProperty;
		setter80.Value = 16.0;
		style27.Add(setter80);
		Setter setter81 = new Setter();
		setter81.Property = TextBlock.FontWeightProperty;
		setter81.Value = FontWeight.DemiBold;
		style27.Add(setter81);
		styles2.Add(style27);
		Style style28 = new Style();
		style28.Selector = ((Selector?)null).OfType(typeof(TextBlock)).Class("count-label");
		Setter setter82 = new Setter();
		setter82.Property = TextBlock.FontSizeProperty;
		setter82.Value = 11.0;
		style28.Add(setter82);
		Setter setter83 = new Setter();
		setter83.Property = TextBlock.ForegroundProperty;
		setter83.Value = new ImmutableSolidColorBrush(4286216842u);
		style28.Add(setter83);
		styles2.Add(style28);
		Style item4 = (style = new Style());
		context.PushParent(style);
		Style style29 = style;
		style29.Selector = ((Selector?)null).OfType(typeof(Border)).Class("config-card");
		Setter setter84 = (setter3 = new Setter());
		context.PushParent(setter3);
		Setter setter85 = setter3;
		setter85.Property = Border.BackgroundProperty;
		StaticResourceExtension staticResourceExtension5 = new StaticResourceExtension("CardTint");
		context.ProvideTargetProperty = CompiledAvaloniaXaml.XamlIlHelpers.Avalonia_002EStyling_002ESetter_002CAvalonia_002EBase_002EValue_0021Property();
		object? value5 = staticResourceExtension5.ProvideValue(context);
		context.ProvideTargetProperty = null;
		setter85.Value = value5;
		context.PopParent();
		style29.Add(setter84);
		Setter setter86 = (setter3 = new Setter());
		context.PushParent(setter3);
		Setter setter87 = setter3;
		setter87.Property = Border.BorderBrushProperty;
		StaticResourceExtension staticResourceExtension6 = new StaticResourceExtension("GlassBorderBrush");
		context.ProvideTargetProperty = CompiledAvaloniaXaml.XamlIlHelpers.Avalonia_002EStyling_002ESetter_002CAvalonia_002EBase_002EValue_0021Property();
		object? value6 = staticResourceExtension6.ProvideValue(context);
		context.ProvideTargetProperty = null;
		setter87.Value = value6;
		context.PopParent();
		style29.Add(setter86);
		Setter setter88 = new Setter();
		setter88.Property = Border.BorderThicknessProperty;
		setter88.Value = new Thickness(1.0, 1.0, 1.0, 1.0);
		style29.Add(setter88);
		Setter setter89 = new Setter();
		setter89.Property = Border.CornerRadiusProperty;
		setter89.Value = new CornerRadius(14.0, 14.0, 14.0, 14.0);
		style29.Add(setter89);
		context.PopParent();
		styles2.Add(item4);
		Style style30 = new Style();
		style30.Selector = ((Selector?)null).OfType(typeof(Border)).Class("profile-icon");
		Setter setter90 = new Setter();
		setter90.Property = Border.BackgroundProperty;
		setter90.Value = new ImmutableSolidColorBrush(1126507829u);
		style30.Add(setter90);
		Setter setter91 = new Setter();
		setter91.Property = Border.BorderBrushProperty;
		setter91.Value = new ImmutableSolidColorBrush(1029199978u);
		style30.Add(setter91);
		Setter setter92 = new Setter();
		setter92.Property = Border.BorderThicknessProperty;
		setter92.Value = new Thickness(1.0, 1.0, 1.0, 1.0);
		style30.Add(setter92);
		Setter setter93 = new Setter();
		setter93.Property = Border.CornerRadiusProperty;
		setter93.Value = new CornerRadius(12.0, 12.0, 12.0, 12.0);
		style30.Add(setter93);
		styles2.Add(style30);
		Style style31 = new Style();
		style31.Selector = ((Selector?)null).OfType(typeof(TextBlock)).Class("config-name");
		Setter setter94 = new Setter();
		setter94.Property = TextBlock.FontSizeProperty;
		setter94.Value = 14.0;
		style31.Add(setter94);
		Setter setter95 = new Setter();
		setter95.Property = TextBlock.FontWeightProperty;
		setter95.Value = FontWeight.DemiBold;
		style31.Add(setter95);
		styles2.Add(style31);
		Style style32 = new Style();
		style32.Selector = ((Selector?)null).OfType(typeof(TextBlock)).Class("config-description");
		Setter setter96 = new Setter();
		setter96.Property = TextBlock.FontSizeProperty;
		setter96.Value = 11.0;
		style32.Add(setter96);
		Setter setter97 = new Setter();
		setter97.Property = TextBlock.ForegroundProperty;
		setter97.Value = new ImmutableSolidColorBrush(4287269530u);
		style32.Add(setter97);
		styles2.Add(style32);
		Style style33 = new Style();
		style33.Selector = ((Selector?)null).OfType(typeof(TextBlock)).Class("meta-label");
		Setter setter98 = new Setter();
		setter98.Property = TextBlock.FontSizeProperty;
		setter98.Value = 10.0;
		style33.Add(setter98);
		Setter setter99 = new Setter();
		setter99.Property = TextBlock.ForegroundProperty;
		setter99.Value = new ImmutableSolidColorBrush(4285164154u);
		style33.Add(setter99);
		styles2.Add(style33);
		Style style34 = new Style();
		style34.Selector = ((Selector?)null).OfType(typeof(TextBlock)).Class("active-pill");
		Setter setter100 = new Setter();
		setter100.Property = TextBlock.BackgroundProperty;
		setter100.Value = new ImmutableSolidColorBrush(591413328u);
		style34.Add(setter100);
		Setter setter101 = new Setter();
		setter101.Property = TextBlock.ForegroundProperty;
		setter101.Value = new ImmutableSolidColorBrush(4290822352u);
		style34.Add(setter101);
		Setter setter102 = new Setter();
		setter102.Property = TextBlock.PaddingProperty;
		setter102.Value = new Thickness(6.0, 3.0, 6.0, 3.0);
		style34.Add(setter102);
		Setter setter103 = new Setter();
		setter103.Property = TextBlock.FontSizeProperty;
		setter103.Value = 9.0;
		style34.Add(setter103);
		Setter setter104 = new Setter();
		setter104.Property = TextBlock.FontWeightProperty;
		setter104.Value = FontWeight.Bold;
		style34.Add(setter104);
		styles2.Add(style34);
		Style style35 = new Style();
		style35.Selector = ((Selector?)null).OfType(typeof(Button)).Class("ghost-button");
		Setter setter105 = new Setter();
		setter105.Property = TemplatedControl.BackgroundProperty;
		setter105.Value = new ImmutableSolidColorBrush(605690410u);
		style35.Add(setter105);
		Setter setter106 = new Setter();
		setter106.Property = TemplatedControl.BorderBrushProperty;
		setter106.Value = new ImmutableSolidColorBrush(1061175378u);
		style35.Add(setter106);
		Setter setter107 = new Setter();
		setter107.Property = TemplatedControl.BorderThicknessProperty;
		setter107.Value = new Thickness(1.0, 1.0, 1.0, 1.0);
		style35.Add(setter107);
		Setter setter108 = new Setter();
		setter108.Property = TemplatedControl.ForegroundProperty;
		setter108.Value = new ImmutableSolidColorBrush(4289769664u);
		style35.Add(setter108);
		Setter setter109 = new Setter();
		setter109.Property = TemplatedControl.PaddingProperty;
		setter109.Value = new Thickness(13.0, 7.0, 13.0, 7.0);
		style35.Add(setter109);
		Setter setter110 = new Setter();
		setter110.Property = TemplatedControl.CornerRadiusProperty;
		setter110.Value = new CornerRadius(8.0, 8.0, 8.0, 8.0);
		style35.Add(setter110);
		Setter setter111 = new Setter();
		setter111.Property = TemplatedControl.FontSizeProperty;
		setter111.Value = 11.0;
		style35.Add(setter111);
		styles2.Add(style35);
		Style item5 = (style = new Style());
		context.PushParent(style);
		Style style36 = style;
		style36.Selector = ((Selector?)null).OfType(typeof(Border)).Class("feature-card");
		Setter setter112 = (setter3 = new Setter());
		context.PushParent(setter3);
		Setter setter113 = setter3;
		setter113.Property = Border.BackgroundProperty;
		StaticResourceExtension staticResourceExtension7 = new StaticResourceExtension("CardTint");
		context.ProvideTargetProperty = CompiledAvaloniaXaml.XamlIlHelpers.Avalonia_002EStyling_002ESetter_002CAvalonia_002EBase_002EValue_0021Property();
		object? value7 = staticResourceExtension7.ProvideValue(context);
		context.ProvideTargetProperty = null;
		setter113.Value = value7;
		context.PopParent();
		style36.Add(setter112);
		Setter setter114 = (setter3 = new Setter());
		context.PushParent(setter3);
		Setter setter115 = setter3;
		setter115.Property = Border.BorderBrushProperty;
		StaticResourceExtension staticResourceExtension8 = new StaticResourceExtension("GlassBorderBrush");
		context.ProvideTargetProperty = CompiledAvaloniaXaml.XamlIlHelpers.Avalonia_002EStyling_002ESetter_002CAvalonia_002EBase_002EValue_0021Property();
		object? value8 = staticResourceExtension8.ProvideValue(context);
		context.ProvideTargetProperty = null;
		setter115.Value = value8;
		context.PopParent();
		style36.Add(setter114);
		Setter setter116 = new Setter();
		setter116.Property = Border.BorderThicknessProperty;
		setter116.Value = new Thickness(1.0, 1.0, 1.0, 1.0);
		style36.Add(setter116);
		Setter setter117 = new Setter();
		setter117.Property = Border.CornerRadiusProperty;
		setter117.Value = new CornerRadius(14.0, 14.0, 14.0, 14.0);
		style36.Add(setter117);
		context.PopParent();
		styles2.Add(item5);
		Style style37 = new Style();
		style37.Selector = ((Selector?)null).OfType(typeof(TextBlock)).Class("metric-value");
		Setter setter118 = new Setter();
		setter118.Property = TextBlock.FontSizeProperty;
		setter118.Value = 30.0;
		style37.Add(setter118);
		Setter setter119 = new Setter();
		setter119.Property = TextBlock.FontWeightProperty;
		setter119.Value = FontWeight.Bold;
		style37.Add(setter119);
		Setter setter120 = new Setter();
		setter120.Property = TextBlock.ForegroundProperty;
		setter120.Value = new ImmutableSolidColorBrush(4292730344u);
		style37.Add(setter120);
		styles2.Add(style37);
		Style style38 = new Style();
		style38.Selector = ((Selector?)null).OfType(typeof(TextBlock)).Class("path-label");
		Setter setter121 = new Setter();
		setter121.Property = TextBlock.FontSizeProperty;
		setter121.Value = 12.0;
		style38.Add(setter121);
		Setter setter122 = new Setter();
		setter122.Property = TextBlock.ForegroundProperty;
		setter122.Value = new ImmutableSolidColorBrush(4290822352u);
		style38.Add(setter122);
		Setter setter123 = new Setter();
		setter123.Property = TextBlock.FontFamilyProperty;
		setter123.Value = new FontFamily(((IUriContext)context).BaseUri, "Consolas");
		style38.Add(setter123);
		styles2.Add(style38);
		Style style39 = new Style();
		style39.Selector = ((Selector?)null).OfType(typeof(Border)).Class("editor-overlay");
		Setter setter124 = new Setter();
		setter124.Property = Border.BackgroundProperty;
		setter124.Value = new ImmutableSolidColorBrush(4195225112u);
		style39.Add(setter124);
		Setter setter125 = new Setter();
		setter125.Property = Border.BorderBrushProperty;
		setter125.Value = new ImmutableSolidColorBrush(1916813397u);
		style39.Add(setter125);
		Setter setter126 = new Setter();
		setter126.Property = Border.BorderThicknessProperty;
		setter126.Value = new Thickness(1.0, 1.0, 1.0, 1.0);
		style39.Add(setter126);
		Setter setter127 = new Setter();
		setter127.Property = Border.CornerRadiusProperty;
		setter127.Value = new CornerRadius(18.0, 18.0, 18.0, 18.0);
		style39.Add(setter127);
		Setter setter128 = new Setter();
		setter128.Property = Border.BoxShadowProperty;
		setter128.Value = BoxShadows.Parse("0 18 60 0 #A005050A");
		style39.Add(setter128);
		styles2.Add(style39);
		Style style40 = new Style();
		style40.Selector = ((Selector?)null).OfType(typeof(TextBlock)).Class("field-label");
		Setter setter129 = new Setter();
		setter129.Property = TextBlock.FontSizeProperty;
		setter129.Value = 11.0;
		style40.Add(setter129);
		Setter setter130 = new Setter();
		setter130.Property = TextBlock.FontWeightProperty;
		setter130.Value = FontWeight.DemiBold;
		style40.Add(setter130);
		Setter setter131 = new Setter();
		setter131.Property = TextBlock.ForegroundProperty;
		setter131.Value = new ImmutableSolidColorBrush(4288322218u);
		style40.Add(setter131);
		styles2.Add(style40);
		Style style41 = new Style();
		style41.Selector = ((Selector?)null).OfType(typeof(TextBox)).Class("editor-input");
		Setter setter132 = new Setter();
		setter132.Property = TemplatedControl.BackgroundProperty;
		setter132.Value = new ImmutableSolidColorBrush(1628574238u);
		style41.Add(setter132);
		Setter setter133 = new Setter();
		setter133.Property = TemplatedControl.BorderBrushProperty;
		setter133.Value = new ImmutableSolidColorBrush(1395995976u);
		style41.Add(setter133);
		Setter setter134 = new Setter();
		setter134.Property = TemplatedControl.ForegroundProperty;
		setter134.Value = new ImmutableSolidColorBrush(4293849077u);
		style41.Add(setter134);
		Setter setter135 = new Setter();
		setter135.Property = TemplatedControl.PaddingProperty;
		setter135.Value = new Thickness(12.0, 10.0, 12.0, 10.0);
		style41.Add(setter135);
		Setter setter136 = new Setter();
		setter136.Property = TemplatedControl.CornerRadiusProperty;
		setter136.Value = new CornerRadius(9.0, 9.0, 9.0, 9.0);
		style41.Add(setter136);
		styles2.Add(style41);
		Style style42 = new Style();
		style42.Selector = ((Selector?)null).OfType(typeof(Button)).Class("danger-button");
		Setter setter137 = new Setter();
		setter137.Property = TemplatedControl.BackgroundProperty;
		setter137.Value = new ImmutableSolidColorBrush(991961136u);
		style42.Add(setter137);
		Setter setter138 = new Setter();
		setter138.Property = TemplatedControl.BorderBrushProperty;
		setter138.Value = new ImmutableSolidColorBrush(2034253906u);
		style42.Add(setter138);
		Setter setter139 = new Setter();
		setter139.Property = TemplatedControl.BorderThicknessProperty;
		setter139.Value = new Thickness(1.0, 1.0, 1.0, 1.0);
		style42.Add(setter139);
		Setter setter140 = new Setter();
		setter140.Property = TemplatedControl.ForegroundProperty;
		setter140.Value = new ImmutableSolidColorBrush(4294942896u);
		style42.Add(setter140);
		Setter setter141 = new Setter();
		setter141.Property = TemplatedControl.PaddingProperty;
		setter141.Value = new Thickness(14.0, 9.0, 14.0, 9.0);
		style42.Add(setter141);
		Setter setter142 = new Setter();
		setter142.Property = TemplatedControl.CornerRadiusProperty;
		setter142.Value = new CornerRadius(9.0, 9.0, 9.0, 9.0);
		style42.Add(setter142);
		styles2.Add(style42);
		Style style43 = new Style();
		style43.Selector = ((Selector?)null).OfType(typeof(Border)).Class("builder-panel");
		Setter setter143 = new Setter();
		setter143.Property = Border.BackgroundProperty;
		setter143.Value = new ImmutableSolidColorBrush(1460999458u);
		style43.Add(setter143);
		Setter setter144 = new Setter();
		setter144.Property = Border.BorderBrushProperty;
		setter144.Value = new ImmutableSolidColorBrush(1061175378u);
		style43.Add(setter144);
		Setter setter145 = new Setter();
		setter145.Property = Border.BorderThicknessProperty;
		setter145.Value = new Thickness(1.0, 1.0, 1.0, 1.0);
		style43.Add(setter145);
		Setter setter146 = new Setter();
		setter146.Property = Border.CornerRadiusProperty;
		setter146.Value = new CornerRadius(14.0, 14.0, 14.0, 14.0);
		style43.Add(setter146);
		styles2.Add(style43);
		Style style44 = new Style();
		style44.Selector = ((Selector?)null).OfType(typeof(ComboBox)).Class("builder-select");
		Setter setter147 = new Setter();
		setter147.Property = TemplatedControl.BackgroundProperty;
		setter147.Value = new ImmutableSolidColorBrush(1628574238u);
		style44.Add(setter147);
		Setter setter148 = new Setter();
		setter148.Property = TemplatedControl.BorderBrushProperty;
		setter148.Value = new ImmutableSolidColorBrush(1395995976u);
		style44.Add(setter148);
		Setter setter149 = new Setter();
		setter149.Property = TemplatedControl.ForegroundProperty;
		setter149.Value = new ImmutableSolidColorBrush(4293849077u);
		style44.Add(setter149);
		Setter setter150 = new Setter();
		setter150.Property = TemplatedControl.PaddingProperty;
		setter150.Value = new Thickness(10.0, 7.0, 10.0, 7.0);
		style44.Add(setter150);
		Setter setter151 = new Setter();
		setter151.Property = TemplatedControl.CornerRadiusProperty;
		setter151.Value = new CornerRadius(9.0, 9.0, 9.0, 9.0);
		style44.Add(setter151);
		Setter setter152 = new Setter();
		setter152.Property = Layoutable.MinHeightProperty;
		setter152.Value = 36.0;
		style44.Add(setter152);
		styles2.Add(style44);
		Style style45 = new Style();
		style45.Selector = ((Selector?)null).OfType(typeof(Button)).Class("mini-button");
		Setter setter153 = new Setter();
		setter153.Property = TemplatedControl.BackgroundProperty;
		setter153.Value = new ImmutableSolidColorBrush(656022058u);
		style45.Add(setter153);
		Setter setter154 = new Setter();
		setter154.Property = TemplatedControl.BorderBrushProperty;
		setter154.Value = new ImmutableSolidColorBrush(1061175378u);
		style45.Add(setter154);
		Setter setter155 = new Setter();
		setter155.Property = TemplatedControl.BorderThicknessProperty;
		setter155.Value = new Thickness(1.0, 1.0, 1.0, 1.0);
		style45.Add(setter155);
		Setter setter156 = new Setter();
		setter156.Property = TemplatedControl.ForegroundProperty;
		setter156.Value = new ImmutableSolidColorBrush(4288716976u);
		style45.Add(setter156);
		Setter setter157 = new Setter();
		setter157.Property = TemplatedControl.PaddingProperty;
		setter157.Value = new Thickness(8.0, 5.0, 8.0, 5.0);
		style45.Add(setter157);
		Setter setter158 = new Setter();
		setter158.Property = TemplatedControl.CornerRadiusProperty;
		setter158.Value = new CornerRadius(7.0, 7.0, 7.0, 7.0);
		style45.Add(setter158);
		Setter setter159 = new Setter();
		setter159.Property = TemplatedControl.FontSizeProperty;
		setter159.Value = 10.0;
		style45.Add(setter159);
		styles2.Add(style45);
		Style style46 = new Style();
		style46.Selector = ((Selector?)null).OfType(typeof(Border)).Class("action-node");
		Setter setter160 = new Setter();
		setter160.Property = Border.BackgroundProperty;
		setter160.Value = new ImmutableSolidColorBrush(991566378u);
		style46.Add(setter160);
		Setter setter161 = new Setter();
		setter161.Property = Border.BorderBrushProperty;
		setter161.Value = new ImmutableSolidColorBrush(893403218u);
		style46.Add(setter161);
		Setter setter162 = new Setter();
		setter162.Property = Border.BorderThicknessProperty;
		setter162.Value = new Thickness(1.0, 1.0, 1.0, 1.0);
		style46.Add(setter162);
		Setter setter163 = new Setter();
		setter163.Property = Border.CornerRadiusProperty;
		setter163.Value = new CornerRadius(10.0, 10.0, 10.0, 10.0);
		style46.Add(setter163);
		styles2.Add(style46);
		Style style47 = new Style();
		style47.Selector = ((Selector?)null).OfType(typeof(Border)).Class("action-node").Class("selected");
		Setter setter164 = new Setter();
		setter164.Property = Border.BackgroundProperty;
		setter164.Value = new ImmutableSolidColorBrush(1479553093u);
		style47.Add(setter164);
		Setter setter165 = new Setter();
		setter165.Property = Border.BorderBrushProperty;
		setter165.Value = new ImmutableSolidColorBrush(2372956298u);
		style47.Add(setter165);
		styles2.Add(style47);
		Style style48 = new Style();
		style48.Selector = ((Selector?)null).OfType(typeof(Border)).Class("node-index");
		Setter setter166 = new Setter();
		setter166.Property = Border.BackgroundProperty;
		setter166.Value = new ImmutableSolidColorBrush(1045450858u);
		style48.Add(setter166);
		Setter setter167 = new Setter();
		setter167.Property = Border.CornerRadiusProperty;
		setter167.Value = new CornerRadius(8.0, 8.0, 8.0, 8.0);
		style48.Add(setter167);
		styles2.Add(style48);
		Style style49 = new Style();
		style49.Selector = ((Selector?)null).OfType(typeof(Button)).Class("node-tool");
		Setter setter168 = new Setter();
		setter168.Property = TemplatedControl.BackgroundProperty;
		setter168.Value = new ImmutableSolidColorBrush(16777215u);
		style49.Add(setter168);
		Setter setter169 = new Setter();
		setter169.Property = TemplatedControl.ForegroundProperty;
		setter169.Value = new ImmutableSolidColorBrush(4288716976u);
		style49.Add(setter169);
		Setter setter170 = new Setter();
		setter170.Property = TemplatedControl.PaddingProperty;
		setter170.Value = new Thickness(4.0, 4.0, 4.0, 4.0);
		style49.Add(setter170);
		Setter setter171 = new Setter();
		setter171.Property = Layoutable.MinWidthProperty;
		setter171.Value = 24.0;
		style49.Add(setter171);
		Setter setter172 = new Setter();
		setter172.Property = Layoutable.MinHeightProperty;
		setter172.Value = 24.0;
		style49.Add(setter172);
		Setter setter173 = new Setter();
		setter173.Property = TemplatedControl.CornerRadiusProperty;
		setter173.Value = new CornerRadius(5.0, 5.0, 5.0, 5.0);
		style49.Add(setter173);
		styles2.Add(style49);
		Style style50 = new Style();
		style50.Selector = ((Selector?)null).OfType(typeof(Button)).Class("node-tool").Class(":pointerover");
		Setter setter174 = new Setter();
		setter174.Property = TemplatedControl.BackgroundProperty;
		setter174.Value = new ImmutableSolidColorBrush(807411760u);
		style50.Add(setter174);
		styles2.Add(style50);
		Style style51 = new Style();
		style51.Selector = ((Selector?)null).OfType(typeof(Button)).Class("node-tool").Class("danger");
		Setter setter175 = new Setter();
		setter175.Property = TemplatedControl.ForegroundProperty;
		setter175.Value = new ImmutableSolidColorBrush(4294942896u);
		style51.Add(setter175);
		styles2.Add(style51);
		Style style52 = new Style();
		style52.Selector = ((Selector?)null).OfType(typeof(Button)).Class("title-bar-btn");
		Setter setter176 = new Setter();
		setter176.Property = TemplatedControl.BackgroundProperty;
		setter176.Value = new ImmutableSolidColorBrush(16777215u);
		style52.Add(setter176);
		Setter setter177 = new Setter();
		setter177.Property = TemplatedControl.ForegroundProperty;
		setter177.Value = new ImmutableSolidColorBrush(4287664288u);
		style52.Add(setter177);
		Setter setter178 = new Setter();
		setter178.Property = TemplatedControl.PaddingProperty;
		setter178.Value = new Thickness(8.0, 4.0, 8.0, 4.0);
		style52.Add(setter178);
		Setter setter179 = new Setter();
		setter179.Property = TemplatedControl.CornerRadiusProperty;
		setter179.Value = new CornerRadius(6.0, 6.0, 6.0, 6.0);
		style52.Add(setter179);
		Setter setter180 = new Setter();
		setter180.Property = TemplatedControl.FontSizeProperty;
		setter180.Value = 14.0;
		style52.Add(setter180);
		Setter setter181 = new Setter();
		setter181.Property = Layoutable.MinWidthProperty;
		setter181.Value = 32.0;
		style52.Add(setter181);
		Setter setter182 = new Setter();
		setter182.Property = Layoutable.MinHeightProperty;
		setter182.Value = 26.0;
		style52.Add(setter182);
		styles2.Add(style52);
		Style style53 = new Style();
		style53.Selector = ((Selector?)null).OfType(typeof(Button)).Class("title-bar-btn").Class(":pointerover");
		Setter setter183 = new Setter();
		setter183.Property = TemplatedControl.BackgroundProperty;
		setter183.Value = new ImmutableSolidColorBrush(739908144u);
		style53.Add(setter183);
		styles2.Add(style53);
		Style style54 = new Style();
		style54.Selector = ((Selector?)null).OfType(typeof(Button)).Class("title-bar-btn").Class("close")
			.Class(":pointerover");
		Setter setter184 = new Setter();
		setter184.Property = TemplatedControl.BackgroundProperty;
		setter184.Value = new ImmutableSolidColorBrush(3291492432u);
		style54.Add(setter184);
		Setter setter185 = new Setter();
		setter185.Property = TemplatedControl.ForegroundProperty;
		setter185.Value = new ImmutableSolidColorBrush(4294945467u);
		style54.Add(setter185);
		styles2.Add(style54);
		Style style55 = new Style();
		style55.Selector = ((Selector?)null).OfType(typeof(Button)).Class("toggle-btn");
		Setter setter186 = new Setter();
		setter186.Property = TemplatedControl.BackgroundProperty;
		setter186.Value = new ImmutableSolidColorBrush(992619066u);
		style55.Add(setter186);
		Setter setter187 = new Setter();
		setter187.Property = TemplatedControl.BorderBrushProperty;
		setter187.Value = new ImmutableSolidColorBrush(1514489178u);
		style55.Add(setter187);
		Setter setter188 = new Setter();
		setter188.Property = TemplatedControl.BorderThicknessProperty;
		setter188.Value = new Thickness(1.0, 1.0, 1.0, 1.0);
		style55.Add(setter188);
		Setter setter189 = new Setter();
		setter189.Property = TemplatedControl.CornerRadiusProperty;
		setter189.Value = new CornerRadius(8.0, 8.0, 8.0, 8.0);
		style55.Add(setter189);
		Setter setter190 = new Setter();
		setter190.Property = TemplatedControl.ForegroundProperty;
		setter190.Value = new ImmutableSolidColorBrush(4288322218u);
		style55.Add(setter190);
		styles2.Add(style55);
		Style style56 = new Style();
		style56.Selector = ((Selector?)null).OfType(typeof(Button)).Class("toggle-btn").Class(":pointerover");
		Setter setter191 = new Setter();
		setter191.Property = TemplatedControl.BackgroundProperty;
		setter191.Value = new ImmutableSolidColorBrush(1262107216u);
		style56.Add(setter191);
		styles2.Add(style56);
		Style style57 = new Style();
		style57.Selector = ((Selector?)null).OfType(typeof(Button)).Class("toggle-btn").Class(":pressed");
		Setter setter192 = new Setter();
		setter192.Property = TemplatedControl.BackgroundProperty;
		setter192.Value = new ImmutableSolidColorBrush(1548372576u);
		style57.Add(setter192);
		styles2.Add(style57);
		Style style58 = new Style();
		style58.Selector = ((Selector?)null).OfType(typeof(Slider)).Class("color-slider").Class("red")
			.Template()
			.OfType(typeof(Thumb));
		Setter setter193 = new Setter();
		setter193.Property = TemplatedControl.BackgroundProperty;
		setter193.Value = new ImmutableSolidColorBrush(4294931588u);
		style58.Add(setter193);
		styles2.Add(style58);
		Style style59 = new Style();
		style59.Selector = ((Selector?)null).OfType(typeof(Slider)).Class("color-slider").Class("green")
			.Template()
			.OfType(typeof(Thumb));
		Setter setter194 = new Setter();
		setter194.Property = TemplatedControl.BackgroundProperty;
		setter194.Value = new ImmutableSolidColorBrush(4285919422u);
		style59.Add(setter194);
		styles2.Add(style59);
		Style style60 = new Style();
		style60.Selector = ((Selector?)null).OfType(typeof(Slider)).Class("color-slider").Class("blue")
			.Template()
			.OfType(typeof(Thumb));
		Setter setter195 = new Setter();
		setter195.Property = TemplatedControl.BackgroundProperty;
		setter195.Value = new ImmutableSolidColorBrush(4287346943u);
		style60.Add(setter195);
		styles2.Add(style60);
		Style style61 = new Style();
		style61.Selector = ((Selector?)null).OfType(typeof(Button)).Class("tab-btn");
		Setter setter196 = new Setter();
		setter196.Property = TemplatedControl.BackgroundProperty;
		setter196.Value = new ImmutableSolidColorBrush(437589280u);
		style61.Add(setter196);
		Setter setter197 = new Setter();
		setter197.Property = TemplatedControl.ForegroundProperty;
		setter197.Value = new ImmutableSolidColorBrush(4287664288u);
		style61.Add(setter197);
		Setter setter198 = new Setter();
		setter198.Property = TemplatedControl.PaddingProperty;
		setter198.Value = new Thickness(16.0, 10.0, 16.0, 10.0);
		style61.Add(setter198);
		Setter setter199 = new Setter();
		setter199.Property = TemplatedControl.FontSizeProperty;
		setter199.Value = 13.0;
		style61.Add(setter199);
		Setter setter200 = new Setter();
		setter200.Property = TemplatedControl.FontWeightProperty;
		setter200.Value = FontWeight.DemiBold;
		style61.Add(setter200);
		Setter setter201 = new Setter();
		setter201.Property = TemplatedControl.CornerRadiusProperty;
		setter201.Value = new CornerRadius(8.0, 8.0, 0.0, 0.0);
		style61.Add(setter201);
		Setter setter202 = new Setter();
		setter202.Property = Layoutable.MarginProperty;
		setter202.Value = new Thickness(0.0, 0.0, 4.0, 0.0);
		style61.Add(setter202);
		Setter setter203 = new Setter();
		setter203.Property = InputElement.CursorProperty;
		setter203.Value = new Cursor(StandardCursorType.Hand);
		style61.Add(setter203);
		Setter setter204 = new Setter();
		setter204.Property = TemplatedControl.BorderThicknessProperty;
		setter204.Value = new Thickness(0.0, 0.0, 0.0, 0.0);
		style61.Add(setter204);
		styles2.Add(style61);
		Style style62 = new Style();
		style62.Selector = ((Selector?)null).OfType(typeof(Button)).Class("tab-btn").Class(":pointerover");
		Setter setter205 = new Setter();
		setter205.Property = TemplatedControl.BackgroundProperty;
		setter205.Value = new ImmutableSolidColorBrush(706748469u);
		style62.Add(setter205);
		Setter setter206 = new Setter();
		setter206.Property = TemplatedControl.ForegroundProperty;
		setter206.Value = new ImmutableSolidColorBrush(4293849077u);
		style62.Add(setter206);
		styles2.Add(style62);
		Style style63 = new Style();
		style63.Selector = ((Selector?)null).OfType(typeof(Button)).Class("tab-btn").Class("tab-active");
		Setter setter207 = new Setter();
		setter207.Property = TemplatedControl.BackgroundProperty;
		setter207.Value = new ImmutableSolidColorBrush(975841861u);
		style63.Add(setter207);
		Setter setter208 = new Setter();
		setter208.Property = TemplatedControl.ForegroundProperty;
		setter208.Value = new ImmutableSolidColorBrush(uint.MaxValue);
		style63.Add(setter208);
		styles2.Add(style63);
		Style style64 = new Style();
		style64.Selector = ((Selector?)null).OfType(typeof(Button)).Class("tab-btn").Class("tab-active")
			.Class(":pointerover");
		Setter setter209 = new Setter();
		setter209.Property = TemplatedControl.BackgroundProperty;
		setter209.Value = new ImmutableSolidColorBrush(1245330005u);
		style64.Add(setter209);
		Setter setter210 = new Setter();
		setter210.Property = TemplatedControl.ForegroundProperty;
		setter210.Value = new ImmutableSolidColorBrush(uint.MaxValue);
		style64.Add(setter210);
		styles2.Add(style64);
		Style overrideWindow = new Style();
		overrideWindow.Selector = ((Selector?)null).OfType(typeof(Window));
		Setter overrideWindowForeground = new Setter();
		overrideWindowForeground.Property = TemplatedControl.ForegroundProperty;
		overrideWindowForeground.Value = new ImmutableSolidColorBrush(4293521640u);
		overrideWindow.Add(overrideWindowForeground);
		styles2.Add(overrideWindow);
		Style overrideShell = new Style();
		overrideShell.Selector = ((Selector?)null).OfType(typeof(Border)).Class("glass-shell");
		Setter overrideShellBackground = new Setter();
		overrideShellBackground.Property = Border.BackgroundProperty;
		overrideShellBackground.Value = new ImmutableSolidColorBrush(4279309845u);
		overrideShell.Add(overrideShellBackground);
		Setter overrideShellBorder = new Setter();
		overrideShellBorder.Property = Border.BorderBrushProperty;
		overrideShellBorder.Value = new ImmutableSolidColorBrush(4282536008u);
		overrideShell.Add(overrideShellBorder);
		styles2.Add(overrideShell);
		Style overrideSidebar = new Style();
		overrideSidebar.Selector = ((Selector?)null).OfType(typeof(Border)).Class("sidebar");
		Setter overrideSidebarBackground = new Setter();
		overrideSidebarBackground.Property = Border.BackgroundProperty;
		overrideSidebarBackground.Value = new ImmutableSolidColorBrush(4278914317u);
		overrideSidebar.Add(overrideSidebarBackground);
		Setter overrideSidebarBorder = new Setter();
		overrideSidebarBorder.Property = Border.BorderBrushProperty;
		overrideSidebarBorder.Value = new ImmutableSolidColorBrush(4280100642u);
		overrideSidebar.Add(overrideSidebarBorder);
		styles2.Add(overrideSidebar);
		Style overrideNav = new Style();
		overrideNav.Selector = ((Selector?)null).OfType(typeof(Button)).Class("nav-item");
		Setter overrideNavBackground = new Setter();
		overrideNavBackground.Property = TemplatedControl.BackgroundProperty;
		overrideNavBackground.Value = new ImmutableSolidColorBrush(4278914317u);
		overrideNav.Add(overrideNavBackground);
		Setter overrideNavForeground = new Setter();
		overrideNavForeground.Property = TemplatedControl.ForegroundProperty;
		overrideNavForeground.Value = new ImmutableSolidColorBrush(4287272591u);
		overrideNav.Add(overrideNavForeground);
		Setter overrideNavRadius = new Setter();
		overrideNavRadius.Property = TemplatedControl.CornerRadiusProperty;
		overrideNavRadius.Value = new CornerRadius(2.0, 2.0, 2.0, 2.0);
		overrideNav.Add(overrideNavRadius);
		styles2.Add(overrideNav);
		Style overrideSelectedNav = new Style();
		overrideSelectedNav.Selector = ((Selector?)null).OfType(typeof(Button)).Class("nav-item").Class("selected");
		Setter overrideSelectedBackground = new Setter();
		overrideSelectedBackground.Property = TemplatedControl.BackgroundProperty;
		overrideSelectedBackground.Value = new ImmutableSolidColorBrush(4280693036u);
		overrideSelectedNav.Add(overrideSelectedBackground);
		Setter overrideSelectedForeground = new Setter();
		overrideSelectedForeground.Property = TemplatedControl.ForegroundProperty;
		overrideSelectedForeground.Value = new ImmutableSolidColorBrush(4291166061u);
		overrideSelectedNav.Add(overrideSelectedForeground);
		styles2.Add(overrideSelectedNav);
		Style overrideCard = new Style();
		overrideCard.Selector = ((Selector?)null).OfType(typeof(Border)).Class("config-card");
		Setter overrideCardBackground = new Setter();
		overrideCardBackground.Property = Border.BackgroundProperty;
		overrideCardBackground.Value = new ImmutableSolidColorBrush(4279573529u);
		overrideCard.Add(overrideCardBackground);
		Setter overrideCardBorder = new Setter();
		overrideCardBorder.Property = Border.BorderBrushProperty;
		overrideCardBorder.Value = new ImmutableSolidColorBrush(4282536008u);
		overrideCard.Add(overrideCardBorder);
		Setter overrideCardRadius = new Setter();
		overrideCardRadius.Property = Border.CornerRadiusProperty;
		overrideCardRadius.Value = new CornerRadius(2.0, 2.0, 2.0, 2.0);
		overrideCard.Add(overrideCardRadius);
		styles2.Add(overrideCard);
		Style overridePrimary = new Style();
		overridePrimary.Selector = ((Selector?)null).OfType(typeof(Button)).Class("primary-button");
		Setter overridePrimaryBackground = new Setter();
		overridePrimaryBackground.Property = TemplatedControl.BackgroundProperty;
		overridePrimaryBackground.Value = new ImmutableSolidColorBrush(4291166061u);
		overridePrimary.Add(overridePrimaryBackground);
		Setter overridePrimaryForeground = new Setter();
		overridePrimaryForeground.Property = TemplatedControl.ForegroundProperty;
		overridePrimaryForeground.Value = new ImmutableSolidColorBrush(4278914317u);
		overridePrimary.Add(overridePrimaryForeground);
		Setter overridePrimaryRadius = new Setter();
		overridePrimaryRadius.Property = TemplatedControl.CornerRadiusProperty;
		overridePrimaryRadius.Value = new CornerRadius(2.0, 2.0, 2.0, 2.0);
		overridePrimary.Add(overridePrimaryRadius);
		styles2.Add(overridePrimary);
		Style overrideGhost = new Style();
		overrideGhost.Selector = ((Selector?)null).OfType(typeof(Button)).Class("ghost-button");
		Setter overrideGhostBackground = new Setter();
		overrideGhostBackground.Property = TemplatedControl.BackgroundProperty;
		overrideGhostBackground.Value = new ImmutableSolidColorBrush(4279309845u);
		overrideGhost.Add(overrideGhostBackground);
		Setter overrideGhostBorder = new Setter();
		overrideGhostBorder.Property = TemplatedControl.BorderBrushProperty;
		overrideGhostBorder.Value = new ImmutableSolidColorBrush(4282536008u);
		overrideGhost.Add(overrideGhostBorder);
		Setter overrideGhostForeground = new Setter();
		overrideGhostForeground.Property = TemplatedControl.ForegroundProperty;
		overrideGhostForeground.Value = new ImmutableSolidColorBrush(4293521640u);
		overrideGhost.Add(overrideGhostForeground);
		Setter overrideGhostRadius = new Setter();
		overrideGhostRadius.Property = TemplatedControl.CornerRadiusProperty;
		overrideGhostRadius.Value = new CornerRadius(2.0, 2.0, 2.0, 2.0);
		overrideGhost.Add(overrideGhostRadius);
		styles2.Add(overrideGhost);
		Style overrideInput = new Style();
		overrideInput.Selector = ((Selector?)null).OfType(typeof(TextBox)).Class("editor-input");
		Setter overrideInputBackground = new Setter();
		overrideInputBackground.Property = TemplatedControl.BackgroundProperty;
		overrideInputBackground.Value = new ImmutableSolidColorBrush(4278914317u);
		overrideInput.Add(overrideInputBackground);
		Setter overrideInputBorder = new Setter();
		overrideInputBorder.Property = TemplatedControl.BorderBrushProperty;
		overrideInputBorder.Value = new ImmutableSolidColorBrush(4282536008u);
		overrideInput.Add(overrideInputBorder);
		Setter overrideInputRadius = new Setter();
		overrideInputRadius.Property = TemplatedControl.CornerRadiusProperty;
		overrideInputRadius.Value = new CornerRadius(2.0, 2.0, 2.0, 2.0);
		overrideInput.Add(overrideInputRadius);
		styles2.Add(overrideInput);
		context.PopParent();
		if ((object)styles is StyledElement styled)
		{
			NameScope.SetNameScope(styled, context.AvaloniaNameScope);
		}
		context.AvaloniaNameScope.Complete();
	}

	public static Styles Build_003A_002FStyles_002FGlassTheme_002Eaxaml(IServiceProvider P_0)
	{
		Styles styles = new Styles();
		Populate_003A_002FStyles_002FGlassTheme_002Eaxaml(P_0, styles);
		return styles;
	}
}
