#pragma checksum "C:\Users\alexi\RiderProjects\Melodie\Melodie\Views\Playlist\Playlist.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "186b240a5d12409555a9df22ecd1176f178fca8c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Melodie.Views.Playlist.Views_Playlist_Playlist), @"mvc.1.0.view", @"/Views/Playlist/Playlist.cshtml")]
namespace Melodie.Views.Playlist
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\alexi\RiderProjects\Melodie\Melodie\Views\_ViewImports.cshtml"
using Melodie;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\alexi\RiderProjects\Melodie\Melodie\Views\_ViewImports.cshtml"
using Melodie.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\alexi\RiderProjects\Melodie\Melodie\Views\_ViewImports.cshtml"
using Melodie.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\alexi\RiderProjects\Melodie\Melodie\Views\Playlist\Playlist.cshtml"
using System.Globalization;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"186b240a5d12409555a9df22ecd1176f178fca8c", @"/Views/Playlist/Playlist.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a277a1b14d162eed286b6a420d442af33c4adef6", @"/Views/_ViewImports.cshtml")]
    public class Views_Playlist_Playlist : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Melodie.Models.Playlist>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/PlaylistsLogoFiller.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("back-to-home"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn orange slide-effect"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\alexi\RiderProjects\Melodie\Melodie\Views\Playlist\Playlist.cshtml"
  
	var bodyClasses = "";
	
	// Music count
	var musicsCount = "";
	
	if (Model.Musics != null)
	{
		var count = Model.Musics.Count;
		musicsCount = count + " musique" + (count > 0 ? "s" : "");
	}
	
	// Delete modal
	var modalClass = "";

	if (ViewBag.OpenDeleteModal != null)
	{
		modalClass = "open";
		bodyClasses += " no-scroll";
	}

	// Music player
	bodyClasses += "has-music-player";
	
	// Body classes
	ViewBag.BodyClasses = bodyClasses;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n\t");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "186b240a5d12409555a9df22ecd1176f178fca8c6057", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
            WriteLiteral("\r\n<div id=\"playlist-container\">\r\n\t");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "186b240a5d12409555a9df22ecd1176f178fca8c7251", async() => {
                WriteLiteral("\r\n\t\t<div class=\"btn-effect-box\"></div>\r\n\t\t<span>&larr; Retour</span>\r\n\t");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\t\r\n\t<div id=\"playlist-info\">\r\n\t\t<div class=\"playlist-logo auto-acronym\"></div>\r\n");
#nullable restore
#line 44 "C:\Users\alexi\RiderProjects\Melodie\Melodie\Views\Playlist\Playlist.cshtml"
         using (Html.BeginForm("Update", "Playlist", FormMethod.Post, new { id = "playlist-info-text" }))
		{
			

#line default
#line hidden
#nullable disable
#nullable restore
#line 46 "C:\Users\alexi\RiderProjects\Melodie\Melodie\Views\Playlist\Playlist.cshtml"
       Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
#nullable restore
#line 48 "C:\Users\alexi\RiderProjects\Melodie\Melodie\Views\Playlist\Playlist.cshtml"
       Write(Html.HiddenFor(p => p.PlaylistId));

#line default
#line hidden
#nullable disable
#nullable restore
#line 49 "C:\Users\alexi\RiderProjects\Melodie\Melodie\Views\Playlist\Playlist.cshtml"
       Write(Html.HiddenFor(p => p.UserId));

#line default
#line hidden
#nullable disable
#nullable restore
#line 50 "C:\Users\alexi\RiderProjects\Melodie\Melodie\Views\Playlist\Playlist.cshtml"
       Write(Html.EditorFor(p => p.Name, new { htmlAttributes = new { @class = "playlist-title bg-on-hover", placeholder = "Nom de la playlist" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t<p class=\"playlist-duration light-text\">");
#nullable restore
#line 51 "C:\Users\alexi\RiderProjects\Melodie\Melodie\Views\Playlist\Playlist.cshtml"
                                               Write(musicsCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 52 "C:\Users\alexi\RiderProjects\Melodie\Melodie\Views\Playlist\Playlist.cshtml"
       Write(Html.EditorFor(p => p.Description, new { htmlAttributes = new { @class = "playlist-desc bg-on-hover", placeholder = "Description" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"			<div class=""playlist-info-buttons"">
				<button class=""btn yellow growing-circle"" type=""submit"">
					<div class=""btn-effect-box""></div>
					<span>Enregistrer</span>
				</button>
				
				<button class=""btn orange showing-icon"" type=""button"" data-open-modal=""1"">
					<div class=""btn-effect-box"">
						<object data=""/images/delete-24px.svg"" type=""image/svg+xml"">
							<img src=""/images/delete-24px.png"" alt=""Delete""/>
						</object>
					</div>
					<span>Supprimer</span>
				</button>
			</div>
");
#nullable restore
#line 69 "C:\Users\alexi\RiderProjects\Melodie\Melodie\Views\Playlist\Playlist.cshtml"
		}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t</div>\r\n\t\r\n\t<div id=\"playlist-delete-confirm\"");
            BeginWriteAttribute("class", " class=\"", 2035, "\"", 2060, 2);
            WriteAttributeValue("", 2043, "modal", 2043, 5, true);
#nullable restore
#line 72 "C:\Users\alexi\RiderProjects\Melodie\Melodie\Views\Playlist\Playlist.cshtml"
WriteAttributeValue(" ", 2048, modalClass, 2049, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" data-modal-id=\"1\">\r\n\t\t<div class=\"modal-wrapper\">\r\n\t\t\t<div class=\"modal-header\">\r\n\t\t\t\t<h3>Confirmation</h3>\r\n\t\t\t</div>\r\n\t\t\t<div class=\"modal-body\">\r\n\t\t\t\t<p>&Eacute;crivez <b>\"");
#nullable restore
#line 78 "C:\Users\alexi\RiderProjects\Melodie\Melodie\Views\Playlist\Playlist.cshtml"
                                 Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"</b> dans la bo&icirc;te ci-dessous pour supprimer la playlist.</p>\r\n\t\t\t\t\r\n");
#nullable restore
#line 80 "C:\Users\alexi\RiderProjects\Melodie\Melodie\Views\Playlist\Playlist.cshtml"
                 using (Html.BeginForm("Delete", "Playlist", FormMethod.Post))
				{
					

#line default
#line hidden
#nullable disable
#nullable restore
#line 82 "C:\Users\alexi\RiderProjects\Melodie\Melodie\Views\Playlist\Playlist.cshtml"
               Write(Html.HiddenFor(p => p.PlaylistId));

#line default
#line hidden
#nullable disable
#nullable restore
#line 83 "C:\Users\alexi\RiderProjects\Melodie\Melodie\Views\Playlist\Playlist.cshtml"
               Write(Html.HiddenFor(p => p.UserId));

#line default
#line hidden
#nullable disable
#nullable restore
#line 84 "C:\Users\alexi\RiderProjects\Melodie\Melodie\Views\Playlist\Playlist.cshtml"
               Write(Html.HiddenFor(p => p.Name));

#line default
#line hidden
#nullable disable
#nullable restore
#line 86 "C:\Users\alexi\RiderProjects\Melodie\Melodie\Views\Playlist\Playlist.cshtml"
               Write(Html.ValidationMessageFor(p => p.DeleteConfirmation, null, new {@class = "error"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t<span class=\"field white field-madoka\">\r\n\t\t\t\t\t\t");
#nullable restore
#line 89 "C:\Users\alexi\RiderProjects\Melodie\Melodie\Views\Playlist\Playlist.cshtml"
                   Write(Html.EditorFor(p => p.DeleteConfirmation, new {htmlAttributes = new {id = "playlist-delete-confirm", @class = "field-input", placeholder = " ", @required = "required"}}));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
						<label class=""field-label"" for=""playlist-delete-confirm"">
							<svg class=""field-graphic"" width=""100%"" height=""100%"" viewBox=""0 0 404 77"" preserveAspectRatio=""none"">
								<path d=""m0,0l404,0l0,77l-404,0l0,-77z""/>
							</svg>
							<span class=""field-label-content"">Confirmation</span>
						</label>
					</span>
");
            WriteLiteral(@"					<div class=""modal-buttons"">
						<button class=""btn yellow slide-effect"" type=""button"" data-close-modal=""1"">
							<div class=""btn-effect-box""></div>
							<span>Annuler</span>
						</button>
						
						<button class=""btn orange showing-icon"" type=""submit"">
                        	<div class=""btn-effect-box"">
                        		<object data=""/images/delete-24px.svg"" type=""image/svg+xml"">
                        			<img src=""/images/delete-24px.png"" alt=""Delete""/>
                        		</object>
                        	</div>
                        	<span>Supprimer</span>
                        </button>
					</div>
");
#nullable restore
#line 113 "C:\Users\alexi\RiderProjects\Melodie\Melodie\Views\Playlist\Playlist.cshtml"
				}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"			</div>
		</div>
	</div>

	<table id=""songs-table"">
		<thead>
			<tr>
				<th class=""song-play-row""></th>
				<th class=""song-name-row"">Nom</th>
				<th class=""song-duration-row"">Durée</th>
				<th class=""song-author-row"">Auteur</th>
				<th class=""song-add-date-row"">Date d'ajout</th>
				<th class=""song-actions-row""></th>
			</tr>
		</thead>
		<tbody>
");
#nullable restore
#line 130 "C:\Users\alexi\RiderProjects\Melodie\Melodie\Views\Playlist\Playlist.cshtml"
             if (Model.Musics != null)
			{
				var i = 0;
				

#line default
#line hidden
#nullable disable
#nullable restore
#line 133 "C:\Users\alexi\RiderProjects\Melodie\Melodie\Views\Playlist\Playlist.cshtml"
                 foreach (var music in Model.Musics)
				{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t<tr class=\"song-row\">\r\n\t\t\t\t\t\t<td class=\"song-play-row no-select\">\r\n\t\t\t\t\t\t\t<div class=\"song-play-btn\" data-id=\"");
#nullable restore
#line 137 "C:\Users\alexi\RiderProjects\Melodie\Melodie\Views\Playlist\Playlist.cshtml"
                                                           Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-uri=\"");
#nullable restore
#line 137 "C:\Users\alexi\RiderProjects\Melodie\Melodie\Views\Playlist\Playlist.cshtml"
                                                                         Write(music.FilePath);

#line default
#line hidden
#nullable disable
            WriteLiteral(@""">
								<object class=""play-icon"" data=""/images/play_arrow-24px.svg"" type=""image/svg+xml"">
									<img src=""/images/play_arrow-24px.png"" alt=""Play""/>
								</object>
								
								<object class=""pause-icon"" data=""/images/pause-24px.svg"" type=""image/svg+xml"">
                                	<img src=""/images/pause-24px.png"" alt=""Pause""/>
                                </object>
							</div>
						</td>
						<td class=""song-name-row"">");
#nullable restore
#line 147 "C:\Users\alexi\RiderProjects\Melodie\Melodie\Views\Playlist\Playlist.cshtml"
                                             Write(music.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\t\t\t\t\t\t<td class=\"song-duration-row\">");
#nullable restore
#line 148 "C:\Users\alexi\RiderProjects\Melodie\Melodie\Views\Playlist\Playlist.cshtml"
                                                 Write(music.Duration);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\t\t\t\t\t\t<td class=\"song-author-row\">");
#nullable restore
#line 149 "C:\Users\alexi\RiderProjects\Melodie\Melodie\Views\Playlist\Playlist.cshtml"
                                               Write(music.Author);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\t\t\t\t\t\t<td class=\"song-add-date-row\">");
#nullable restore
#line 150 "C:\Users\alexi\RiderProjects\Melodie\Melodie\Views\Playlist\Playlist.cshtml"
                                                 Write(music.CreationDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\t\t\t\t\t\t<td class=\"song-actions-row\">\r\n");
#nullable restore
#line 152 "C:\Users\alexi\RiderProjects\Melodie\Melodie\Views\Playlist\Playlist.cshtml"
                               await Html.RenderPartialAsync("DelMusicFormPartial", new Music { MusicId = music.MusicId, PlaylistId = music.PlaylistId }); 

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t</td>\r\n\t\t\t\t\t</tr>\r\n");
#nullable restore
#line 155 "C:\Users\alexi\RiderProjects\Melodie\Melodie\Views\Playlist\Playlist.cshtml"

					i++;
				}

#line default
#line hidden
#nullable disable
#nullable restore
#line 157 "C:\Users\alexi\RiderProjects\Melodie\Melodie\Views\Playlist\Playlist.cshtml"
                 
			}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\r\n\t\t\t<tr class=\"table-space\"></tr>\r\n\t\t\t<tr>\r\n\t\t\t\t<td class=\"song-play-row\"></td>\r\n");
#nullable restore
#line 163 "C:\Users\alexi\RiderProjects\Melodie\Melodie\Views\Playlist\Playlist.cshtml"
                   await Html.RenderPartialAsync("AddMusicFormPartial", new Music {PlaylistId = Model.PlaylistId}); 

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t</tr>\r\n\t\t</tbody>\r\n\t</table>\r\n</div>\r\n\r\n");
#nullable restore
#line 169 "C:\Users\alexi\RiderProjects\Melodie\Melodie\Views\Playlist\Playlist.cshtml"
   await Html.RenderPartialAsync("MusicPlayer"); 

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IMelodieDbService MelodieDbService { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Melodie.Models.Playlist> Html { get; private set; }
    }
}
#pragma warning restore 1591
