using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace petshi
{


    public class mani
    {
        public Response response { get; set; }
        public Meta meta { get; set; }
        public Data data { get; set; }
    }

    public class Response
    {
        public bool status { get; set; }
        public int code { get; set; }
        public object state { get; set; }
    }

    public class Meta
    {
        public string q { get; set; }
        public string type { get; set; }
        public string filter { get; set; }
    }

    public class Data
    {
        public int num_found { get; set; }
        public Result[] results { get; set; }
    }

    public class Result
    {
        public string id { get; set; }
        public string title { get; set; }
        public string title_en { get; set; }
        public string text { get; set; }
        public string pron { get; set; }
        public string source { get; set; }
        public string db { get; set; }
        public int num { get; set; }
    }

    public class Arz
    {
        public Sana_Buy_Usd sana_buy_usd { get; set; }
        public Sana_Buy_Eur sana_buy_eur { get; set; }
        public Sana_Buy_Aed sana_buy_aed { get; set; }
        public Sana_Sell_Usd sana_sell_usd { get; set; }
        public Sana_Sell_Eur sana_sell_eur { get; set; }
        public Sana_Sell_Aed sana_sell_aed { get; set; }
    }

    public class Sana_Buy_Usd
    {
        public string title { get; set; }
        public string price { get; set; }
        public string jdate { get; set; }
        public string gdate { get; set; }
    }

    public class Sana_Buy_Eur
    {
        public string title { get; set; }
        public string price { get; set; }
        public string jdate { get; set; }
        public string gdate { get; set; }
    }

    public class Sana_Buy_Aed
    {
        public string title { get; set; }
        public string price { get; set; }
        public string jdate { get; set; }
        public string gdate { get; set; }
    }

    public class Sana_Sell_Usd
    {
        public string title { get; set; }
        public string price { get; set; }
        public string jdate { get; set; }
        public string gdate { get; set; }
    }

    public class Sana_Sell_Eur
    {
        public string title { get; set; }
        public string price { get; set; }
        public string jdate { get; set; }
        public string gdate { get; set; }
    }

    public class Sana_Sell_Aed
    {
        public string title { get; set; }
        public string price { get; set; }
        public string jdate { get; set; }
        public string gdate { get; set; }
    }

    public class weather
    {
        public Location location { get; set; }
        public Current current { get; set; }
        public Forecast forecast { get; set; }
    }

    public class Location
    {
        public string name { get; set; }
        public string region { get; set; }
        public string country { get; set; }
        public float lat { get; set; }
        public float lon { get; set; }
        public string tz_id { get; set; }
        public int localtime_epoch { get; set; }
        public string localtime { get; set; }
    }

    public class Current
    {
        public int last_updated_epoch { get; set; }
        public string last_updated { get; set; }
        public float temp_c { get; set; }
        public float temp_f { get; set; }
        public int is_day { get; set; }
        public Condition condition { get; set; }
        public float wind_mph { get; set; }
        public float wind_kph { get; set; }
        public int wind_degree { get; set; }
        public string wind_dir { get; set; }
        public float pressure_mb { get; set; }
        public float pressure_in { get; set; }
        public float precip_mm { get; set; }
        public float precip_in { get; set; }
        public int humidity { get; set; }
        public int cloud { get; set; }
        public float feelslike_c { get; set; }
        public float feelslike_f { get; set; }
        public float vis_km { get; set; }
        public float vis_miles { get; set; }
    }

    public class Condition
    {
        public string text { get; set; }
        public string icon { get; set; }
        public int code { get; set; }
    }

    public class Forecast
    {
        public Forecastday[] forecastday { get; set; }
    }

    public class Forecastday
    {
        public string date { get; set; }
        public int date_epoch { get; set; }
        public Day day { get; set; }
        public Astro astro { get; set; }
    }

    public class Day
    {
        public float maxtemp_c { get; set; }
        public float maxtemp_f { get; set; }
        public float mintemp_c { get; set; }
        public float mintemp_f { get; set; }
        public float avgtemp_c { get; set; }
        public float avgtemp_f { get; set; }
        public float maxwind_mph { get; set; }
        public float maxwind_kph { get; set; }
        public float totalprecip_mm { get; set; }
        public float totalprecip_in { get; set; }
        public float avgvis_km { get; set; }
        public float avgvis_miles { get; set; }
        public float avghumidity { get; set; }
        public Condition1 condition { get; set; }
        public float uv { get; set; }
    }

    public class Condition1
    {
        public string text { get; set; }
        public string icon { get; set; }
        public int code { get; set; }
    }

    public class Astro
    {
        public string sunrise { get; set; }
        public string sunset { get; set; }
        public string moonrise { get; set; }
        public string moonset { get; set; }
    }


}
