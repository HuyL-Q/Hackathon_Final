using System.Collections.Generic;
using UnityEngine;
using System;
//using Nancy.Json;
using System.Linq;
using Microsoft.CSharp;
using System.Net.Http;
using System.Threading.Tasks;

public class ApiConverter : MonoBehaviour
{
    public HttpClient _client;
    public HttpResponseMessage _response;
    public class ApiConv : JsonConverter<dat> { }
    public class ApiConvItem : JsonConverter<item> { }
    public class ApiConvLink : JsonConverter<Link> { }
    public ApiConverter()
    {
        _client = new HttpClient();
        _client.BaseAddress = new Uri("http://localhost:3000/");
        _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
    }


    public async Task<List<item>> GetListChoosen()
    {
        _response = await _client.GetAsync($"users");
        var json = await _response.Content.ReadAsStringAsync();
        ApiConv conv = new ApiConv();
        dat list = conv.getObjectfromText(json);
        GameControllerE.datList = list.Data;
        return list.Data;
    }
    public async Task<item> GetItemChoosen(string link)
    {
        _response = await _client.GetAsync(link);
        item item;
        var json = await _response.Content.ReadAsStringAsync();
        ApiConvItem conv = new ApiConvItem();
        item = conv.getObjectfromText(json);
        return item;
    }
    public async Task<Link> GetLinkList(string link)
    {
        _client.BaseAddress = new Uri("http://localhost:8000/");
        Link ls = new Link();
        _response = await _client.GetAsync(link);
        var json = await _response.Content.ReadAsStringAsync();
        ApiConvLink conv = new ApiConvLink();
        ls = conv.getObjectfromText(json);
        return ls;
    }
}
