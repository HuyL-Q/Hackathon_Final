//using CryptoForUser.DAO;
//using CryptoForUser.Model;
//using Nancy.Json;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Http;
//using System.Text;
//using System.Threading.Tasks;

//namespace CryptoForUser.Respository
//{
//    internal class KucoinRepository
//    {
//        public HttpClient _client;
//        public HttpResponseMessage _response;


//        public KucoinRepository()
//        {
//            _client = new HttpClient();
//            _client.BaseAddress = new Uri("https://api.kucoin.com/");
//            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
//        }



//        public async Task<List<ticker>> GetListChoosen(int userId, int cexId, int level)
//        {
//            List<ticker> list = new List<ticker>();
//            _response = await _client.GetAsync($"api/v1/market/allTickers");
//            var json = await _response.Content.ReadAsStringAsync();




//            var js = new JavaScriptSerializer();
//            var d = js.Deserialize<dynamic>(json);




//            Int32 length = d["data"]["ticker"].Count;


//            List<Symbol> a = DAOLite.SymbolDAO.GetSymbolByUserAndCex(userId, cexId, level);

//            for (int i = 0; i < length; i++)
//            {
//                foreach(Symbol x in a)
//                {
//                    if (d["data"]["ticker"][i]["symbolName"]==x.Name)
//                    {
//                        list.Add(
//                            new ticker(
//                                d["data"]["ticker"][i]["symbolName"],
//                                Convert.ToDouble(d["data"]["ticker"][i]["last"]),
//                                Convert.ToDouble(d["data"]["ticker"][i]["changeRate"]),
//                                Convert.ToDouble(d["data"]["ticker"][i]["volValue"])
//                        )
//                    );
//                    }
//                }


                
//            }

//            return list;
//        }

//        public async Task<List<ticker>> GetTickersForUser(string changeRateLv, string Amount)
//        {
//            List<ticker> list = new List<ticker>();
//            _response = await _client.GetAsync($"api/v1/market/allTickers");
//            var json = await _response.Content.ReadAsStringAsync();




//            var js = new JavaScriptSerializer();
//            var d = js.Deserialize<dynamic>(json);

//            Int32 length = d["data"]["ticker"].Count;


//            for (int i = 0; i < length; i++)
//            {
//                if (changeRateLv != "" && Amount == "")
//                {
//                    if (Convert.ToDouble(d["data"]["ticker"][i]["changeRate"]) >=Convert.ToDouble(changeRateLv)/100)
//                    {
//                        list.Add(
//                            new ticker(
//                            d["data"]["ticker"][i]["symbolName"],
//                            Convert.ToDouble(d["data"]["ticker"][i]["last"]),
//                            Convert.ToDouble(d["data"]["ticker"][i]["changeRate"]),
//                            Convert.ToDouble(d["data"]["ticker"][i]["volValue"])
//                        )
//                    );
//                    }
                    

//                }else if (Amount != "" && changeRateLv == "")
//                {
//                    if (Convert.ToDouble(d["data"]["ticker"][i]["volValue"]) >= Convert.ToDouble(Amount))
//                    {
//                        list.Add(
//                            new ticker(
//                            d["data"]["ticker"][i]["symbolName"],
//                            Convert.ToDouble(d["data"]["ticker"][i]["last"]),
//                            Convert.ToDouble(d["data"]["ticker"][i]["changeRate"]),
//                            Convert.ToDouble(d["data"]["ticker"][i]["volValue"])
//                        )
//                    );
//                    }
//                }
//                else
//                {
//                    if (Convert.ToDouble(d["data"]["ticker"][i]["volValue"]) >= Convert.ToDouble(Amount) && Convert.ToDouble(d["data"]["ticker"][i]["changeRate"]) >= Convert.ToDouble(changeRateLv)/100)
//                    {
//                        list.Add(
//                            new ticker(
//                            d["data"]["ticker"][i]["symbolName"],
//                            Convert.ToDouble(d["data"]["ticker"][i]["last"]),
//                            Convert.ToDouble(d["data"]["ticker"][i]["changeRate"]),
//                            Convert.ToDouble(d["data"]["ticker"][i]["volValue"])
//                        )
//                    );
//                    }
//                }
                
//            }
//            return list;

//        }





//        public async Task<List<ticker>> GetList()
//        {
//            List<ticker> list = new List<ticker>();
//            _response = await _client.GetAsync($"api/v1/market/allTickers");
//            var json = await _response.Content.ReadAsStringAsync();




//            var js = new JavaScriptSerializer();
//            var d = js.Deserialize<dynamic>(json);




//            Int32 length = d["data"]["ticker"].Count;



//            for (int i = 0; i < length; i++)
//            {
//                list.Add(
//                    new ticker(              
//                        d["data"]["ticker"][i]["symbolName"],
//                        Convert.ToDouble(d["data"]["ticker"][i]["last"]),
//                        Convert.ToDouble(d["data"]["ticker"][i]["changeRate"]),
//                        Convert.ToDouble(d["data"]["ticker"][i]["volValue"])              
//                        )
//                    );
//            }

//            return list;
//        }




//    }
//}
