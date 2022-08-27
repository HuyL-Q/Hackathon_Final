using System.Collections.Generic;
using UnityEngine;
using System;
//using Nancy.Json;
using System.Linq;
using Microsoft.CSharp;
using System.Net.Http;
using System.Threading.Tasks;

public class ApiConverter
{
    public HttpClient _client;
    public HttpResponseMessage _response;
    public string id;
    public class ApiConv : JsonConverter<dat> { }
    public class ApiConvItem : JsonConverter<item> { }
    public class ApiConvLink : JsonConverter<Link> { }
    public class ApiGetLink : JsonConverter<GetLink> { }
    public ApiConverter()
    {
        _client = new HttpClient();
        _client.BaseAddress = new Uri("http://hackathonfinal.lhr.rocks/");
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
    public void setId(string id)
    {
        this.id = id;
    }
    public List<string> CutLink(string text)
    {
        List<string> list = new List<string>();
        string cur = "";
        for (int i = 0; i < text.Length; i++)
        {
            char c = text[i];
            if (c == null)
                continue;
            cur += c;
            if (cur.EndsWith(".json"))
            {
                list.Add(cur);
                cur = "";
            }
        }
        return list;
    }
    public async Task<List<item>> GetItem()
    {//link 1
        List<item> ls = new List<item>();
        int count = 0;
        var json = "";
        while (true)
        {
            try
            {
                _response = await _client.GetAsync($"token?principalId=" + id);
                json = await _response.Content.ReadAsStringAsync();//link 2
                if (json.Contains("https") || count > 2)
                    break;
                count++;
            }
            catch (Exception E)
            {
                Debug.Log(E.Message);
            }
        }
        List<string> link = CutLink(json);
        foreach (var item in link)
        {
            try
            {
                _client = new HttpClient();
                _client.BaseAddress = new Uri(item);
                _response = await _client.GetAsync($"");
                json = await _response.Content.ReadAsStringAsync();
                ApiGetLink agl = new ApiGetLink();
                GetLink gl = agl.getObjectfromText(json);
                _client = new HttpClient();
                _client.BaseAddress = new Uri(gl.image);//link 3
                _response = await _client.GetAsync($"");
                json = await _response.Content.ReadAsStringAsync();
                ApiConvItem aci = new ApiConvItem();
                ls.Add(aci.getObjectfromText(json));
            }
            catch (Exception E)
            {
                Debug.Log(E.Message + "this mess came from 89");
            }
        }
        //return json;
        return ls;
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
