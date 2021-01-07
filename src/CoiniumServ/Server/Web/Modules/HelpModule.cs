﻿#region License
//
//     MIT License
//
//     CoiniumServ - Crypto Currency Mining Pool Server Software
//
//     Copyright (C) 2013 - 2017, CoiniumServ Project
//     Copyright (C) 2017 - 2021 The Merit Foundation
//
//     Permission is hereby granted, free of charge, to any person obtaining a copy
//     of this software and associated documentation files (the "Software"), to deal
//     in the Software without restriction, including without limitation the rights
//     to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//     copies of the Software, and to permit persons to whom the Software is
//     furnished to do so, subject to the following conditions:
//
//     The above copyright notice and this permission notice shall be included in all
//     copies or substantial portions of the Software.
//
//     THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//     IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//     FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//     AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//     LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//     OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//     SOFTWARE.
//
#endregion

using CoiniumServ.Configuration;
using CoiniumServ.Mining.Software;
using CoiniumServ.Pools;
using CoiniumServ.Server.Web.Models.GettingStarted;
using Nancy;
using Nancy.CustomErrors;
using Nancy.Helpers;

namespace CoiniumServ.Server.Web.Modules
{
    public class HelpModule:NancyModule
    {

        private const string slug = "MRT";

        public HelpModule(IPoolManager poolManager, IConfigManager configManager, ISoftwareRepository softwareRepository)
            :base("/help")
        {
            Get["/faq"] = _ =>
            {
                ViewBag.Header = "Frequently Asked Questions";

                return View["faq"];
            };

            Get["/gettingstarted/"] = _ =>
            {
                var model = new GettingStartedModel
                {
                    Stack = configManager.StackConfig,
                    Pool = poolManager.Get(slug)
                };

                ViewBag.ActiveLink = "help";

                return View["gettingstarted/index", model];
            };

            Get["/miningsoftware/"] = _ =>
            {
                ViewBag.ActiveLink = "help";

                return View["miningsoftware", softwareRepository];
            };
        }
    }
}
