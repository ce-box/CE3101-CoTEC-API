import json

with open('CotecAPI\Resources\countries.json') as f:
    cty_json = json.load(f)
    cty_json = cty_json["data"]
    

def json_to_sql(continent_code):
    
    output = ""
    for cty in cty_json:

        if continent_code == cty["Continent_Code"]:

            name = cty["Country_Name"].split(',')[0]
            code = cty["Three_Letter_Country_Code"]
            if code is "": code = cty["Two_Letter_Country_Code"]
            url_code = cty["Two_Letter_Country_Code"]
            
            tmp = "(\'{0}\',\'{1}\',\'{2}\',\'https://www.countryflags.io/{3}/flat/64.png\'),\n".format(name,code,continent_code,url_code)
            output += tmp

    print(output)

if __name__ == "__main__":
    json_to_sql("AN")
