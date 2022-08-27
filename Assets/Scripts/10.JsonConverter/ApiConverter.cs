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
}
