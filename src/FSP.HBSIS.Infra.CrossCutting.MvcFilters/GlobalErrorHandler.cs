using System.Web.Mvc;

namespace FSP.HBSIS.Infra.CrossCutting.MvcFilters
{
    public class GlobalErrorHandler : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            // LOG AUDITORIA

            if (filterContext.Exception != null)
            {
                // Manipular a EX
                // Injetar alguma LIB de tratamento de erro
                //  -> Gravar log do erro
                //  -> Email para o admin
                //  -> Retornar cod de erro amigavel

                //filterContext.Controller.TempData["ErrorCode"] = "000555";
                filterContext.Controller.TempData["ErrorCode"] = filterContext.Exception.Message.ToString();
            }

            base.OnActionExecuted(filterContext);
        }
    }
}