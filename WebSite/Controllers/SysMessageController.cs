﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.SystemBusiness;
using Model.SystemModel;

namespace WebSite.Controllers
{
    public class SysMessageController : BaseController
    {
        private SysMessageBusiness business = new SysMessageBusiness();
        // GET: SysMessage
        [PageAuthorizeFilter]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetMsgList(SysMessageFilter filter)
        {
            filter.ToUser = CurrentUser.Id;
            var data = business.GetSysMessageList(filter, out int total);
            return Json(new TableDataModel(total, data));
        }

        public ActionResult GetNotReadCount()
        {
            return Json(business.GetNotReadCount(CurrentUser.Id));
        }

        public ActionResult MarkRead(List<Guid> messageId)
        {
            try
            {
                return Json(new JsonMessage(business.MarkRead(messageId,CurrentUser.Id)));
            }
            catch (Exception e)
            {
                return Json(new JsonMessage(false, e.Message));
            }
        }
    }
}