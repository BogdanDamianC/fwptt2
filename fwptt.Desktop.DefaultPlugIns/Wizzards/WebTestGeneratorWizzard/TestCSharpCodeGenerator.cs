﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 15.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace fwptt.Desktop.DefaultPlugIns.Wizzards.WebTestGeneratorWizzard
{
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Personal\Projects\fwptt2\fwptt.Desktop.DefaultPlugIns\Wizzards\WebTestGeneratorWizzard\TestCSharpCodeGenerator.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public partial class TestCSharpCodeGenerator : TestCSharpCodeGeneratorBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write(@"using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;
using System.Net;
using System.IO;
using System.Text;
using fwptt.TestProject.Run;
using fwptt.TestProject.Run.Data;
using fwptt.Web.HTTP.Test;
using fwptt.Web.HTTP.Test.Data;
using CsQuery;
using Newtonsoft.Json;

namespace IETests
{
	public class ");
            
            #line 19 "C:\Personal\Projects\fwptt2\fwptt.Desktop.DefaultPlugIns\Wizzards\WebTestGeneratorWizzard\TestCSharpCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TestDefinition.ClassName));
            
            #line default
            #line hidden
            this.Write(":BaseHTTPTest\r\n\t{\r\n\t\tprivate const string SiteDomainPropName = \"Site Domain\";\r\n\t\t" +
                    "");
            
            #line 22 "C:\Personal\Projects\fwptt2\fwptt.Desktop.DefaultPlugIns\Wizzards\WebTestGeneratorWizzard\TestCSharpCodeGenerator.tt"
 if(usedParams.Length > 0) {
            
            #line default
            #line hidden
            this.Write("\t\tstring ");
            
            #line 23 "C:\Personal\Projects\fwptt2\fwptt.Desktop.DefaultPlugIns\Wizzards\WebTestGeneratorWizzard\TestCSharpCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(string.Join(",", usedParams)));
            
            #line default
            #line hidden
            this.Write(";\r\n\t\t");
            
            #line 24 "C:\Personal\Projects\fwptt2\fwptt.Desktop.DefaultPlugIns\Wizzards\WebTestGeneratorWizzard\TestCSharpCodeGenerator.tt"
}
            
            #line default
            #line hidden
            this.Write("\r\n\t\t");
            
            #line 26 "C:\Personal\Projects\fwptt2\fwptt.Desktop.DefaultPlugIns\Wizzards\WebTestGeneratorWizzard\TestCSharpCodeGenerator.tt"
 for(int index = 0; index < TestDefinition.Requests.Count; index++) 
		{
			var request = TestDefinition.Requests[index];
		
            
            #line default
            #line hidden
            this.Write("\t\r\n\t\t#region Request - ");
            
            #line 31 "C:\Personal\Projects\fwptt2\fwptt.Desktop.DefaultPlugIns\Wizzards\WebTestGeneratorWizzard\TestCSharpCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(index));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 31 "C:\Personal\Projects\fwptt2\fwptt.Desktop.DefaultPlugIns\Wizzards\WebTestGeneratorWizzard\TestCSharpCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(useSiteDomainPath(request.URL)?getRelativePath(request.URL):request.URL.ToString()));
            
            #line default
            #line hidden
            this.Write("\r\n\t\tprivate async Task ");
            
            #line 32 "C:\Personal\Projects\fwptt2\fwptt.Desktop.DefaultPlugIns\Wizzards\WebTestGeneratorWizzard\TestCSharpCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetMethodName(index)));
            
            #line default
            #line hidden
            this.Write("()\r\n\t\t{\r\n            if (!await InitializeCurrentRequest().ConfigureAwait(false))" +
                    "\r\n                return;\r\n\t\t\t");
            
            #line 36 "C:\Personal\Projects\fwptt2\fwptt.Desktop.DefaultPlugIns\Wizzards\WebTestGeneratorWizzard\TestCSharpCodeGenerator.tt"
 if(useSiteDomainPath(request.URL)){ 
            
            #line default
            #line hidden
            this.Write("\t\t\tCurrentRequest.Request.URL = new Uri(Properties[SiteDomainPropName] + @\"");
            
            #line 37 "C:\Personal\Projects\fwptt2\fwptt.Desktop.DefaultPlugIns\Wizzards\WebTestGeneratorWizzard\TestCSharpCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(getRelativePath(request.URL)));
            
            #line default
            #line hidden
            this.Write("\");\r\n\t\t\t");
            
            #line 38 "C:\Personal\Projects\fwptt2\fwptt.Desktop.DefaultPlugIns\Wizzards\WebTestGeneratorWizzard\TestCSharpCodeGenerator.tt"
 }else  { 
            
            #line default
            #line hidden
            this.Write("\t\t\tCurrentRequest.Request.URL = new Uri(@\"");
            
            #line 39 "C:\Personal\Projects\fwptt2\fwptt.Desktop.DefaultPlugIns\Wizzards\WebTestGeneratorWizzard\TestCSharpCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(request.URL));
            
            #line default
            #line hidden
            this.Write("\");\r\n\t\t\t");
            
            #line 40 "C:\Personal\Projects\fwptt2\fwptt.Desktop.DefaultPlugIns\Wizzards\WebTestGeneratorWizzard\TestCSharpCodeGenerator.tt"
 }  
            
            #line default
            #line hidden
            this.Write("\t\t\t\r\n\t\t\tCurrentRequest.Request.Port = ");
            
            #line 42 "C:\Personal\Projects\fwptt2\fwptt.Desktop.DefaultPlugIns\Wizzards\WebTestGeneratorWizzard\TestCSharpCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(request.Port));
            
            #line default
            #line hidden
            this.Write(";\r\n\t\t\tCurrentRequest.Request.RequestMethod = @\"");
            
            #line 43 "C:\Personal\Projects\fwptt2\fwptt.Desktop.DefaultPlugIns\Wizzards\WebTestGeneratorWizzard\TestCSharpCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(request.RequestMethod??"GET"));
            
            #line default
            #line hidden
            this.Write("\";\r\n\t\t\t");
            
            #line 44 "C:\Personal\Projects\fwptt2\fwptt.Desktop.DefaultPlugIns\Wizzards\WebTestGeneratorWizzard\TestCSharpCodeGenerator.tt"
if(request.RequestMethod == "POST" || request.RequestMethod == "PUT") { 
            
            #line default
            #line hidden
            this.Write("\t\t\tCurrentRequest.Request.PayloadContentType = @\"");
            
            #line 45 "C:\Personal\Projects\fwptt2\fwptt.Desktop.DefaultPlugIns\Wizzards\WebTestGeneratorWizzard\TestCSharpCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(request.PayloadContentType??"application/x-www-form-urlencoded"));
            
            #line default
            #line hidden
            this.Write("\";\r\n\t\t\t");
            
            #line 46 "C:\Personal\Projects\fwptt2\fwptt.Desktop.DefaultPlugIns\Wizzards\WebTestGeneratorWizzard\TestCSharpCodeGenerator.tt"
 if(request.PostParams == null || request.PostParams.Count == 0){ 
            
            #line default
            #line hidden
            this.Write("\t\t\tCurrentRequest.Request.Payload = ");
            
            #line 47 "C:\Personal\Projects\fwptt2\fwptt.Desktop.DefaultPlugIns\Wizzards\WebTestGeneratorWizzard\TestCSharpCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetQuotedValue(request.Payload)));
            
            #line default
            #line hidden
            this.Write(";\r\n\t\t\t");
            
            #line 48 "C:\Personal\Projects\fwptt2\fwptt.Desktop.DefaultPlugIns\Wizzards\WebTestGeneratorWizzard\TestCSharpCodeGenerator.tt"
 }   
			} 
            
            #line default
            #line hidden
            this.Write("\t\t\t");
            
            #line 50 "C:\Personal\Projects\fwptt2\fwptt.Desktop.DefaultPlugIns\Wizzards\WebTestGeneratorWizzard\TestCSharpCodeGenerator.tt"
 foreach(var qp in request.QueryParams) 
			{ 
            
            #line default
            #line hidden
            this.Write("CurrentRequest.Request.QueryParams.Add(new RequestParam(@\"");
            
            #line 51 "C:\Personal\Projects\fwptt2\fwptt.Desktop.DefaultPlugIns\Wizzards\WebTestGeneratorWizzard\TestCSharpCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(qp.ParamName));
            
            #line default
            #line hidden
            this.Write("\",");
            
            #line 51 "C:\Personal\Projects\fwptt2\fwptt.Desktop.DefaultPlugIns\Wizzards\WebTestGeneratorWizzard\TestCSharpCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetQuotedValue(qp.ParamValue)));
            
            #line default
            #line hidden
            this.Write("));\r\n\t\t\t");
            
            #line 52 "C:\Personal\Projects\fwptt2\fwptt.Desktop.DefaultPlugIns\Wizzards\WebTestGeneratorWizzard\TestCSharpCodeGenerator.tt"
 }  
            
            #line default
            #line hidden
            this.Write("\t\t\t\r\n\t\t\t");
            
            #line 54 "C:\Personal\Projects\fwptt2\fwptt.Desktop.DefaultPlugIns\Wizzards\WebTestGeneratorWizzard\TestCSharpCodeGenerator.tt"
 foreach(var pp in request.PostParams) 
			{ 
            
            #line default
            #line hidden
            this.Write("CurrentRequest.Request.PostParams.Add(new RequestParam(@\"");
            
            #line 55 "C:\Personal\Projects\fwptt2\fwptt.Desktop.DefaultPlugIns\Wizzards\WebTestGeneratorWizzard\TestCSharpCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(pp.ParamName));
            
            #line default
            #line hidden
            this.Write("\",");
            
            #line 55 "C:\Personal\Projects\fwptt2\fwptt.Desktop.DefaultPlugIns\Wizzards\WebTestGeneratorWizzard\TestCSharpCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetPostParamValue(index, pp)));
            
            #line default
            #line hidden
            this.Write("));\r\n\t\t\t");
            
            #line 56 "C:\Personal\Projects\fwptt2\fwptt.Desktop.DefaultPlugIns\Wizzards\WebTestGeneratorWizzard\TestCSharpCodeGenerator.tt"
 }  
            
            #line default
            #line hidden
            this.Write("\r\n\t\t\tvar req = BuildRequest();\t\t\r\n\t\t\tawait ExecuteRequest(req,(resp)=>{\r\n\t\t\t\t");
            
            #line 60 "C:\Personal\Projects\fwptt2\fwptt.Desktop.DefaultPlugIns\Wizzards\WebTestGeneratorWizzard\TestCSharpCodeGenerator.tt"
 if(paramsToSave[index].Length > 0) { 
            
            #line default
            #line hidden
            this.Write("\t\t\t\tCQ requestDOM = CQ.Create(CurrentRequest.Response);\r\n\t\t\t\t");
            
            #line 62 "C:\Personal\Projects\fwptt2\fwptt.Desktop.DefaultPlugIns\Wizzards\WebTestGeneratorWizzard\TestCSharpCodeGenerator.tt"
for(int psIndex = 0; psIndex < paramsToSave[index].Length; psIndex++){
            
            #line default
            #line hidden
            this.Write("\t\t\t\t");
            
            #line 63 "C:\Personal\Projects\fwptt2\fwptt.Desktop.DefaultPlugIns\Wizzards\WebTestGeneratorWizzard\TestCSharpCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetCodeNameForParam(paramsToSave[index][psIndex])));
            
            #line default
            #line hidden
            this.Write(" = requestDOM[\"#");
            
            #line 63 "C:\Personal\Projects\fwptt2\fwptt.Desktop.DefaultPlugIns\Wizzards\WebTestGeneratorWizzard\TestCSharpCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(paramsToSave[index][psIndex]));
            
            #line default
            #line hidden
            this.Write("\"].Val();\r\n\t\t\t\t");
            
            #line 64 "C:\Personal\Projects\fwptt2\fwptt.Desktop.DefaultPlugIns\Wizzards\WebTestGeneratorWizzard\TestCSharpCodeGenerator.tt"
}} 
            
            #line default
            #line hidden
            this.Write("\t\t\t\treturn true;//Add response handling stuff here if needed - return true for th" +
                    "e current run to continue or false to cancel it\r\n\t\t\t}).ConfigureAwait(false);\r\n\t" +
                    "\t}\r\n\t\t#endregion\r\n\t\t");
            
            #line 69 "C:\Personal\Projects\fwptt2\fwptt.Desktop.DefaultPlugIns\Wizzards\WebTestGeneratorWizzard\TestCSharpCodeGenerator.tt"
 } 
            
            #line default
            #line hidden
            this.Write(@"		
		protected override async Task RunTest()
		{
		    //uncomment this to enable the fiddler proxy - this is usefull if you want to debug a run with fiddler
		    //this.Proxy = new WebProxy(""http://127.0.0.1:8888"");     // FIDDLER PROXY - ENABLE TO SEE THE RESULTS IN FIDDLER, do not use it for the real load tests
			InitializeHttpClient(Properties[SiteDomainPropName],
			""Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)""
			,""image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*"");
			");
            
            #line 78 "C:\Personal\Projects\fwptt2\fwptt.Desktop.DefaultPlugIns\Wizzards\WebTestGeneratorWizzard\TestCSharpCodeGenerator.tt"
 for(int index = 0; index < TestDefinition.Requests.Count; index++) 
			{ 
            
            #line default
            #line hidden
            this.Write("await ");
            
            #line 79 "C:\Personal\Projects\fwptt2\fwptt.Desktop.DefaultPlugIns\Wizzards\WebTestGeneratorWizzard\TestCSharpCodeGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetMethodName(index)));
            
            #line default
            #line hidden
            this.Write("().ConfigureAwait(false);\r\n\t\t\t");
            
            #line 80 "C:\Personal\Projects\fwptt2\fwptt.Desktop.DefaultPlugIns\Wizzards\WebTestGeneratorWizzard\TestCSharpCodeGenerator.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\t\r\n\t\t}\r\n\t}\r\n}");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public class TestCSharpCodeGeneratorBase
    {
        #region Fields
        private global::System.Text.StringBuilder generationEnvironmentField;
        private global::System.CodeDom.Compiler.CompilerErrorCollection errorsField;
        private global::System.Collections.Generic.List<int> indentLengthsField;
        private string currentIndentField = "";
        private bool endsWithNewline;
        private global::System.Collections.Generic.IDictionary<string, object> sessionField;
        #endregion
        #region Properties
        /// <summary>
        /// The string builder that generation-time code is using to assemble generated output
        /// </summary>
        protected System.Text.StringBuilder GenerationEnvironment
        {
            get
            {
                if ((this.generationEnvironmentField == null))
                {
                    this.generationEnvironmentField = new global::System.Text.StringBuilder();
                }
                return this.generationEnvironmentField;
            }
            set
            {
                this.generationEnvironmentField = value;
            }
        }
        /// <summary>
        /// The error collection for the generation process
        /// </summary>
        public System.CodeDom.Compiler.CompilerErrorCollection Errors
        {
            get
            {
                if ((this.errorsField == null))
                {
                    this.errorsField = new global::System.CodeDom.Compiler.CompilerErrorCollection();
                }
                return this.errorsField;
            }
        }
        /// <summary>
        /// A list of the lengths of each indent that was added with PushIndent
        /// </summary>
        private System.Collections.Generic.List<int> indentLengths
        {
            get
            {
                if ((this.indentLengthsField == null))
                {
                    this.indentLengthsField = new global::System.Collections.Generic.List<int>();
                }
                return this.indentLengthsField;
            }
        }
        /// <summary>
        /// Gets the current indent we use when adding lines to the output
        /// </summary>
        public string CurrentIndent
        {
            get
            {
                return this.currentIndentField;
            }
        }
        /// <summary>
        /// Current transformation session
        /// </summary>
        public virtual global::System.Collections.Generic.IDictionary<string, object> Session
        {
            get
            {
                return this.sessionField;
            }
            set
            {
                this.sessionField = value;
            }
        }
        #endregion
        #region Transform-time helpers
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void Write(string textToAppend)
        {
            if (string.IsNullOrEmpty(textToAppend))
            {
                return;
            }
            // If we're starting off, or if the previous text ended with a newline,
            // we have to append the current indent first.
            if (((this.GenerationEnvironment.Length == 0) 
                        || this.endsWithNewline))
            {
                this.GenerationEnvironment.Append(this.currentIndentField);
                this.endsWithNewline = false;
            }
            // Check if the current text ends with a newline
            if (textToAppend.EndsWith(global::System.Environment.NewLine, global::System.StringComparison.CurrentCulture))
            {
                this.endsWithNewline = true;
            }
            // This is an optimization. If the current indent is "", then we don't have to do any
            // of the more complex stuff further down.
            if ((this.currentIndentField.Length == 0))
            {
                this.GenerationEnvironment.Append(textToAppend);
                return;
            }
            // Everywhere there is a newline in the text, add an indent after it
            textToAppend = textToAppend.Replace(global::System.Environment.NewLine, (global::System.Environment.NewLine + this.currentIndentField));
            // If the text ends with a newline, then we should strip off the indent added at the very end
            // because the appropriate indent will be added when the next time Write() is called
            if (this.endsWithNewline)
            {
                this.GenerationEnvironment.Append(textToAppend, 0, (textToAppend.Length - this.currentIndentField.Length));
            }
            else
            {
                this.GenerationEnvironment.Append(textToAppend);
            }
        }
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void WriteLine(string textToAppend)
        {
            this.Write(textToAppend);
            this.GenerationEnvironment.AppendLine();
            this.endsWithNewline = true;
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void Write(string format, params object[] args)
        {
            this.Write(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void WriteLine(string format, params object[] args)
        {
            this.WriteLine(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Raise an error
        /// </summary>
        public void Error(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Raise a warning
        /// </summary>
        public void Warning(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            error.IsWarning = true;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Increase the indent
        /// </summary>
        public void PushIndent(string indent)
        {
            if ((indent == null))
            {
                throw new global::System.ArgumentNullException("indent");
            }
            this.currentIndentField = (this.currentIndentField + indent);
            this.indentLengths.Add(indent.Length);
        }
        /// <summary>
        /// Remove the last indent that was added with PushIndent
        /// </summary>
        public string PopIndent()
        {
            string returnValue = "";
            if ((this.indentLengths.Count > 0))
            {
                int indentLength = this.indentLengths[(this.indentLengths.Count - 1)];
                this.indentLengths.RemoveAt((this.indentLengths.Count - 1));
                if ((indentLength > 0))
                {
                    returnValue = this.currentIndentField.Substring((this.currentIndentField.Length - indentLength));
                    this.currentIndentField = this.currentIndentField.Remove((this.currentIndentField.Length - indentLength));
                }
            }
            return returnValue;
        }
        /// <summary>
        /// Remove any indentation
        /// </summary>
        public void ClearIndent()
        {
            this.indentLengths.Clear();
            this.currentIndentField = "";
        }
        #endregion
        #region ToString Helpers
        /// <summary>
        /// Utility class to produce culture-oriented representation of an object as a string.
        /// </summary>
        public class ToStringInstanceHelper
        {
            private System.IFormatProvider formatProviderField  = global::System.Globalization.CultureInfo.InvariantCulture;
            /// <summary>
            /// Gets or sets format provider to be used by ToStringWithCulture method.
            /// </summary>
            public System.IFormatProvider FormatProvider
            {
                get
                {
                    return this.formatProviderField ;
                }
                set
                {
                    if ((value != null))
                    {
                        this.formatProviderField  = value;
                    }
                }
            }
            /// <summary>
            /// This is called from the compile/run appdomain to convert objects within an expression block to a string
            /// </summary>
            public string ToStringWithCulture(object objectToConvert)
            {
                if ((objectToConvert == null))
                {
                    throw new global::System.ArgumentNullException("objectToConvert");
                }
                System.Type t = objectToConvert.GetType();
                System.Reflection.MethodInfo method = t.GetMethod("ToString", new System.Type[] {
                            typeof(System.IFormatProvider)});
                if ((method == null))
                {
                    return objectToConvert.ToString();
                }
                else
                {
                    return ((string)(method.Invoke(objectToConvert, new object[] {
                                this.formatProviderField })));
                }
            }
        }
        private ToStringInstanceHelper toStringHelperField = new ToStringInstanceHelper();
        /// <summary>
        /// Helper to produce culture-oriented representation of an object as a string
        /// </summary>
        public ToStringInstanceHelper ToStringHelper
        {
            get
            {
                return this.toStringHelperField;
            }
        }
        #endregion
    }
    #endregion
}
