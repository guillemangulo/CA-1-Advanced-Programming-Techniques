#WEB SCRAPPER
import requests
from bs4 import BeautifulSoup
import csv
import os


def scrape_hotel_page(url, hotel_name):

    response = requests.get(url)
    response.raise_for_status()

    #asuring text is UTF-8 to avoid format issues
    response.encoding = "utf-8"

    soup = BeautifulSoup(response.text, "html.parser")

    #info is there in that case 
    cards = soup.select(".hotel-card")

    results = []

    for card in cards:
        #inside .hotel-description we have room info
        name_tag = card.select_one(".hotel-description")
        
        if name_tag:
            name = name_tag.get_text(" ", strip=True)
            name = name.replace('"', "").strip()
        else:
            name = "Unknown Room"

        #extract price
        price_tag = card.select_one(".current-price")
        if price_tag:
            price = price_tag.get_text(" ", strip=True)
        else:
            price = "N/A"

        #save in "results" dictionary
        results.append({
            "Hotel": hotel_name,
            "Room": name,
            "Price": price,
            "URL": url
        })

    return results

def save_to_csv(data, filename):
  
    current = os.path.dirname(os.path.abspath(__file__))
    filepath = os.path.join(current, filename)

    with open(filepath, "w", newline="") as f:
        headers = ["Hotel", "Room", "Price", "URL"]
        writer = csv.DictWriter(f, fieldnames=headers)
        writer.writeheader()
        writer.writerows(data)

    return filepath

def read_csv(filename):

    current = os.path.dirname(os.path.abspath(__file__))
    filepath = os.path.join(current, filename)

    with open(filepath, "r") as f:
        reader = csv.DictReader(f)
        hotels = []

        for row in reader:
            hotels.append(row)
        return hotels


def main():
    #urls from pages created by class mate
    url1 = "https://hotel1.tiiny.site/"
    url2 = "https://booking-hotels2.tiiny.site/"

    data = []
    data.extend(scrape_hotel_page(url1, "Hotel 1"))
    data.extend(scrape_hotel_page(url2, "Hotel 2"))

    #save in CSV 
    csv_file = "hotel_data.csv"  
    save_to_csv(data, csv_file) 

    #show in terminal
    print("\nCSV created...")
    rows = read_csv(csv_file)
    for row in rows: 
        print(row)
 

if __name__ == "__main__":
    main()
 
  



