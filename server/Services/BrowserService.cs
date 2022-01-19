//using CaotunSpring.DH.Tools.Data;
//using RadzenDh5.Models;
using RadzenDh5.DHModels;
using RadzenDh5.DHData;
using System;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using RadzenDh5.Data;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using DocumentFormat.OpenXml.Packaging;
using System.Reflection;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml;
using Microsoft.AspNetCore.Hosting;
using Microsoft.JSInterop;
using System.Threading.Tasks;
namespace CaotunSpring.Util
{
    //https://blazor.tips/blazor-how-to-ready-window-dimensions/


    public class BrowserService
    {
        private readonly IJSRuntime _js;

        public BrowserService(IJSRuntime js)
        {
            _js = js;
        }

        public async Task<BrowserDimension> GetDimensions()
        {
            return await _js.InvokeAsync<BrowserDimension>("getDimensions");
        }

    }

    public class BrowserDimension
    {
        public int Width { get; set; }
        public int Height { get; set; }
    }


}
