

using System;
using System.Collections.Generic;
using System.Text;
using Contensive.BaseClasses;

using PageExtension.Models;

namespace Contensive.Addons.PageExtensions {
    namespace Views {
        public class CharsetConvertClass : AddonBaseClass {
            public object Models { get; private set; }

            //
            // ====================================================================================================
            /// <summary>
            /// return a 
            /// </summary>
            /// <param name="cp"></param>
            /// <returns></returns
            public override object Execute(CPBaseClass cp) {
               
                try {
                    var pagecontentList = PageExtension.Models.PageContentModel.createList(cp, "createkey=0");
                    var Encw1252 = Encoding.GetEncoding("windows-1252");
                    var EncUTF8 = Encoding.GetEncoding("utf-8");
                  
                    foreach (var page in pagecontentList) {
                        string htmlEncoded = EncUTF8.GetString(Encoding.Convert(Encw1252, EncUTF8, Encoding.Default.GetBytes(page.Copyfilename)));
                        page.Copyfilename = htmlEncoded;
                         htmlEncoded = EncUTF8.GetString(Encoding.Convert(Encw1252, EncUTF8, Encoding.Default.GetBytes(page.BriefFilename)));
                        page.BriefFilename = htmlEncoded;
                        page.CreateKey = 1;
                        page.save(cp);
                    };

                    }
                catch (Exception ex) {
                    cp.Site.ErrorReport(ex);
                    return "";
                };
                return "";
            }
            
        }

    }
}
