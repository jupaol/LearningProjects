using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Msts.Topics.Chapter03.Lesson01
{
    public partial class PageLifeCycle : System.Web.UI.Page
    {
        public PageLifeCycle()
        {
            this.CommitTransaction += PageLifeCycle_CommitTransaction;
            this.AbortTransaction += PageLifeCycle_AbortTransaction;
            
            this.Error += PageLifeCycle_Error;

            this.PreInit += PageLifeCycle_PreInit;
            this.Init += PageLifeCycle_Init;
            this.InitComplete += PageLifeCycle_InitComplete;
            this.PreLoad += PageLifeCycle_PreLoad;
            this.Load += PageLifeCycle_Load;
            this.LoadComplete += PageLifeCycle_LoadComplete;
            this.PreRender += PageLifeCycle_PreRender;
            this.DataBinding += PageLifeCycle_DataBinding;
            this.PreRenderComplete += PageLifeCycle_PreRenderComplete;
            this.SaveStateComplete += PageLifeCycle_SaveStateComplete;
            this.Unload += PageLifeCycle_Unload;
            this.Disposed += PageLifeCycle_Disposed;
        }

        protected override void InitializeCulture()
        {
            HttpContext.Current.Trace.Warn(MethodInfo.GetCurrentMethod().Name);
            base.InitializeCulture();
        }

        protected override System.Collections.Specialized.NameValueCollection DeterminePostBackMode()
        {
            HttpContext.Current.Trace.Warn(MethodInfo.GetCurrentMethod().Name);
            return base.DeterminePostBackMode();
        }

        protected override void TrackViewState()
        {
            HttpContext.Current.Trace.Warn(MethodInfo.GetCurrentMethod().Name);
            base.TrackViewState();
        }

        protected override object LoadPageStateFromPersistenceMedium()
        {
            HttpContext.Current.Trace.Warn(MethodInfo.GetCurrentMethod().Name);
            return base.LoadPageStateFromPersistenceMedium();
        }

        protected override void LoadViewState(object savedState)
        {
            HttpContext.Current.Trace.Warn(MethodInfo.GetCurrentMethod().Name);
            base.LoadViewState(savedState);
        }

        protected override void RaisePostBackEvent(IPostBackEventHandler sourceControl, string eventArgument)
        {
            HttpContext.Current.Trace.Warn(MethodInfo.GetCurrentMethod().Name);
            base.RaisePostBackEvent(sourceControl, eventArgument);
        }

        public override void Validate()
        {
            HttpContext.Current.Trace.Warn(MethodInfo.GetCurrentMethod().Name);
            base.Validate();
        }

        public override void Validate(string validationGroup)
        {
            HttpContext.Current.Trace.Warn(MethodInfo.GetCurrentMethod().Name);
            base.Validate(validationGroup);
        }

        protected override object SaveViewState()
        {
            HttpContext.Current.Trace.Warn(MethodInfo.GetCurrentMethod().Name);
            return base.SaveViewState();
        }

        protected override void SavePageStateToPersistenceMedium(object state)
        {
            HttpContext.Current.Trace.Warn(MethodInfo.GetCurrentMethod().Name);
            base.SavePageStateToPersistenceMedium(state);
        }

        protected override object SaveControlState()
        {
            HttpContext.Current.Trace.Warn(MethodInfo.GetCurrentMethod().Name);
            return base.SaveControlState();
        }

        protected override void LoadControlState(object savedState)
        {
            HttpContext.Current.Trace.Warn(MethodInfo.GetCurrentMethod().Name);
            base.LoadControlState(savedState);
        }

        public override void RenderControl(HtmlTextWriter writer)
        {
            HttpContext.Current.Trace.Warn(MethodInfo.GetCurrentMethod().Name);
            base.RenderControl(writer);
        }

        protected override void Render(HtmlTextWriter writer)
        {
            HttpContext.Current.Trace.Warn(MethodInfo.GetCurrentMethod().Name);
            base.Render(writer);
        }

        protected override void OnAbortTransaction(EventArgs e)
        {
            HttpContext.Current.Trace.Warn(MethodInfo.GetCurrentMethod().Name);
            base.OnAbortTransaction(e);
        }

        protected override bool OnBubbleEvent(object source, EventArgs args)
        {
            HttpContext.Current.Trace.Warn(MethodInfo.GetCurrentMethod().Name);
            return base.OnBubbleEvent(source, args);
        }

        protected override void OnCommitTransaction(EventArgs e)
        {
            HttpContext.Current.Trace.Warn(MethodInfo.GetCurrentMethod().Name);
            base.OnCommitTransaction(e);
        }

        protected override void OnDataBinding(EventArgs e)
        {
            HttpContext.Current.Trace.Warn(MethodInfo.GetCurrentMethod().Name);
            base.OnDataBinding(e);
        }

        protected override void OnError(EventArgs e)
        {
            HttpContext.Current.Trace.Warn(MethodInfo.GetCurrentMethod().Name);
            base.OnError(e);
        }

        protected override void OnInit(EventArgs e)
        {
            HttpContext.Current.Trace.Warn(MethodInfo.GetCurrentMethod().Name);
            base.OnInit(e);
        }

        protected override void OnInitComplete(EventArgs e)
        {
            HttpContext.Current.Trace.Warn(MethodInfo.GetCurrentMethod().Name);
            base.OnInitComplete(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            HttpContext.Current.Trace.Warn(MethodInfo.GetCurrentMethod().Name);
            base.OnLoad(e);
        }

        protected override void OnLoadComplete(EventArgs e)
        {
            HttpContext.Current.Trace.Warn(MethodInfo.GetCurrentMethod().Name);
            base.OnLoadComplete(e);
        }

        protected override void OnPreInit(EventArgs e)
        {
            HttpContext.Current.Trace.Warn(MethodInfo.GetCurrentMethod().Name);
            base.OnPreInit(e);
        }

        protected override void OnPreLoad(EventArgs e)
        {
            HttpContext.Current.Trace.Warn(MethodInfo.GetCurrentMethod().Name);
            base.OnPreLoad(e);
        }

        protected override void OnPreRender(EventArgs e)
        {
            HttpContext.Current.Trace.Warn(MethodInfo.GetCurrentMethod().Name);
            base.OnPreRender(e);
        }

        protected override void OnPreRenderComplete(EventArgs e)
        {
            HttpContext.Current.Trace.Warn(MethodInfo.GetCurrentMethod().Name);
            base.OnPreRenderComplete(e);
        }

        protected override void OnSaveStateComplete(EventArgs e)
        {
            HttpContext.Current.Trace.Warn(MethodInfo.GetCurrentMethod().Name);
            base.OnSaveStateComplete(e);
        }

        protected override void OnUnload(EventArgs e)
        {
            HttpContext.Current.Trace.Warn(MethodInfo.GetCurrentMethod().Name);
            base.OnUnload(e);
        }

        public override void ApplyStyleSheetSkin(Page page)
        {
            HttpContext.Current.Trace.Warn(MethodInfo.GetCurrentMethod().Name);
            base.ApplyStyleSheetSkin(page);
        }

        public override string StyleSheetTheme
        {
            get
            {
                HttpContext.Current.Trace.Warn(MethodInfo.GetCurrentMethod().Name);
                return base.StyleSheetTheme;
            }
            set
            {
                base.StyleSheetTheme = value;
            }
        }

        public override void DataBind()
        {
            HttpContext.Current.Trace.Warn(MethodInfo.GetCurrentMethod().Name);
            base.DataBind();
        }

        protected override void DataBind(bool raiseOnDataBinding)
        {
            HttpContext.Current.Trace.Warn(MethodInfo.GetCurrentMethod().Name);
            base.DataBind(raiseOnDataBinding);
        }

        public override void ProcessRequest(HttpContext context)
        {
            HttpContext.Current.Trace.Warn(MethodInfo.GetCurrentMethod().Name);
            base.ProcessRequest(context);
        }

        public override string Theme
        {
            get
            {
                HttpContext.Current.Trace.Warn(MethodInfo.GetCurrentMethod().Name);
                return base.Theme;
            }
            set
            {
                base.Theme = value;
            }
        }

        void PageLifeCycle_Unload(object sender, EventArgs e)
        {
            HttpContext.Current.Trace.Warn(MethodInfo.GetCurrentMethod().Name);
        }

        void PageLifeCycle_SaveStateComplete(object sender, EventArgs e)
        {
            HttpContext.Current.Trace.Warn(MethodInfo.GetCurrentMethod().Name);
        }

        void PageLifeCycle_PreRenderComplete(object sender, EventArgs e)
        {
            HttpContext.Current.Trace.Warn(MethodInfo.GetCurrentMethod().Name);
        }

        void PageLifeCycle_PreRender(object sender, EventArgs e)
        {
            HttpContext.Current.Trace.Warn(MethodInfo.GetCurrentMethod().Name);
        }

        void PageLifeCycle_PreLoad(object sender, EventArgs e)
        {
            HttpContext.Current.Trace.Warn(MethodInfo.GetCurrentMethod().Name);
        }

        void PageLifeCycle_PreInit(object sender, EventArgs e)
        {
            HttpContext.Current.Trace.Warn(MethodInfo.GetCurrentMethod().Name);
        }

        void PageLifeCycle_LoadComplete(object sender, EventArgs e)
        {
            HttpContext.Current.Trace.Warn(MethodInfo.GetCurrentMethod().Name);
        }

        void PageLifeCycle_InitComplete(object sender, EventArgs e)
        {
            HttpContext.Current.Trace.Warn(MethodInfo.GetCurrentMethod().Name);
        }

        void PageLifeCycle_Init(object sender, EventArgs e)
        {
            HttpContext.Current.Trace.Warn(MethodInfo.GetCurrentMethod().Name);
        }

        void PageLifeCycle_Error(object sender, EventArgs e)
        {
            HttpContext.Current.Trace.Warn(MethodInfo.GetCurrentMethod().Name);
        }

        void PageLifeCycle_Disposed(object sender, EventArgs e)
        {
            HttpContext.Current.Trace.Warn(MethodInfo.GetCurrentMethod().Name);
        }

        void PageLifeCycle_DataBinding(object sender, EventArgs e)
        {
            HttpContext.Current.Trace.Warn(MethodInfo.GetCurrentMethod().Name);
        }

        void PageLifeCycle_CommitTransaction(object sender, EventArgs e)
        {
            HttpContext.Current.Trace.Warn(MethodInfo.GetCurrentMethod().Name);
        }

        void PageLifeCycle_AbortTransaction(object sender, EventArgs e)
        {
            HttpContext.Current.Trace.Warn(MethodInfo.GetCurrentMethod().Name);
        }

        void PageLifeCycle_Load(object sender, EventArgs e)
        {
            HttpContext.Current.Trace.Warn(MethodInfo.GetCurrentMethod().Name);
        }

        protected void postButton_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Trace.Warn(MethodInfo.GetCurrentMethod().Name);
        }

        protected void ddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            HttpContext.Current.Trace.Warn(MethodInfo.GetCurrentMethod().Name);
        }

        protected void chk_CheckedChanged(object sender, EventArgs e)
        {
            HttpContext.Current.Trace.Warn(MethodInfo.GetCurrentMethod().Name);
        }
    }
}