using System;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace OrderManagerPrototype.Updater
{
    //TODO: use it if manual parsing is required
	public class OrderRequest
	{		
		static public JObject Execute(string url)
		{
			var request = WebRequest.Create(url);
			var response = (HttpWebResponse) request.GetResponse();

            string text;

			using (var sr = new StreamReader(response.GetResponseStream()))
			{
    			text = sr.ReadToEnd();
			}

            return(JObject.Parse(text));
		}
	}
}