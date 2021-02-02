﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;


namespace MarketApi
{
    public class CostomJsonFormatter : JsonMediaTypeFormatter
    {
        //public CostomJsonFormatter()
        //{
        //    this.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("text/html"));
        //}
        //public override void SetDefaultContentHeaders(Type type, HttpContentHeaders headers, MediaTypeHeaderValue mediaType)
        //{
        //    base.SetDefaultContentHeaders(type, headers, mediaType);
        //    headers.ContentType = new MediaTypeHeaderValue("application/json");


        //}
    }
    public static class WebApiConfig 
    {

        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }

            );

           // GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            //GlobalConfiguration.Configuration.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);

            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.All;
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.Add(new CostomJsonFormatter());
            json.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("application/json"));

            //var json = config.Formatters.JsonFormatter;
            //json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            //config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}



//public class CostomJsonFormatter : JsonMediaTypeFormatter
//{
//    public CostomJsonFormatter()
//    {
//        this.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("text/html"));
//    }
//    public override void SetDefaultContentHeaders(Type type, HttpContentHeaders headers, MediaTypeHeaderValue mediaType)
//    {
//        base.SetDefaultContentHeaders(type, headers, mediaType);
//        headers.ContentType = new MediaTypeHeaderValue("application/json");
//    }
//}
//public static class WebApiConfig
//{
//    public static void Register(HttpConfiguration config)
//    {
//        // Web API configuration and services

//        // Web API routes
//        config.MapHttpAttributeRoutes();

//        config.Routes.MapHttpRoute(
//            name: "DefaultApi",
//            routeTemplate: "api/{controller}/{id}",
//            defaults: new { id = RouteParameter.Optional }
//        );


//        //config.Formatters.Add(new CostomJsonFormatter());
//        //json.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("application/json"));

//        //var json = config.Formatters.JsonFormatter;
//        //json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.All;
//        //config.Formatters.Remove(config.Formatters.XmlFormatter);

//    }
//}