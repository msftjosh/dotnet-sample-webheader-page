using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Linq;

namespace CurrentTimeApp.Controllers
{
    public class HomeController : Controller
        {
            public IActionResult Index()
                {
                    ViewBag.CurrentTime = DateTime.Now.ToString();
                    ViewBag.TimeZone = TimeZoneInfo.Local.StandardName;
                    ViewBag.ClientIP = HttpContext.Connection.RemoteIpAddress.ToString();
                    ViewBag.ClientPublicIP = Request.Headers["X-Azure-ClientIP"];
                    ViewBag.XForwardedFor = Request.Headers["x-forwarded-for"];
                    ViewBag.ServerHostname = Dns.GetHostName();
                    ViewBag.ServerPublicIP = Request.Headers["Host"];
                    // Retrieve the IPv4 address
                    IPAddress ipv4Address = null;
                    foreach (IPAddress ip in Dns.GetHostEntry(ViewBag.ServerHostname).AddressList)
                        {
                            if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                                {
                                    ipv4Address = ip;
                                    break;
                                }
                        }
                    ViewBag.ServerIPAddress = HttpContext.Connection.LocalIpAddress.ToString();
                    ViewBag.HostHeaders = Request.Headers;

                    // Create a dictionary to store client headers
                    var clientHeaders = new Dictionary<string, string>();
                    foreach (var header in Request.Headers)
                        {
                            clientHeaders[header.Key] = header.Value;
                        }
                    return View();
                    }
                }
            }