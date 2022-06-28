# Spectrum
Demo Website: https://spectrumx.azurewebsites.net/
* Outbound SMTP connection via port 25 is completely blocked in Azure, Hence email function will not work on demo website.
* to get the project run, download the repo and run on localhost 
* (Can be solve using SendGrid)

# Poster
![5262](https://user-images.githubusercontent.com/30100720/176193721-6a20df58-de86-47b0-82db-5aae1ff55fc1.png)

# Proposed Level of Achievement
Apollo 11

# Aim:
* Eliminate the need of Pager used by restaurants and provide free notification service to restaurants, Food courts and hawker via the use of smartphone.
* Make offline ordering process more convenient.
* Provide free notification service to all restaurants, Food courts and hawker by using non-disruptive advertisement from the subscription notification page.
   * Background can be use as advertisement
    <img src="https://user-images.githubusercontent.com/30100720/174734696-ba783cd6-c523-4a6b-9087-06548dec0113.png" width="200">

# User Stories
Customers: 
1) Scan the QR Code provider by stall owner using their personal smartphone.
2) Access the Stall website and subscribe to the notification service using either email or web notification.
3) Free to move around or doing other activities while browsing through the menu and waiting for your order to be ready.
4) Receive notification when order is ready for collection.

Stall Owner:
1) Generate receipt.
2) Update receipt status when complete.
* Note that User stories for Stall Owner is to be reviewed 
* Trying to automate by using either
   1) Machine learning
   2) Construct an entire new framework to handle order process instead of provide improvement on the existing process

# Motivation
Problem:
1) Long Mundane Waiting Time when purchasing food.
2) Life can be more meaningful instead of queuing for your order while you could be doing something else.
3) Not all Shops have Pager System.
4) Even with Pager systems, a Pager Set is usually quite expensive and can spoil through wear and tear. (Upwards of a few hundred dollars per set)
5) Sanitary concerns (pager systems have to be reused by different customer regularly)

# Qualifications
1) Wei Wen Jie 
    1. Background: Computer Science
    2. Experience: CS1011S, CS1231S, CS2030S, CS2100
    3. Testimonial: Singtel Internship (automation), National NAPROCK Competition, MAPP design contest by Singapore Polytechnic, AWS IoT App challenge
2) Gerald Koh Kheng Guan
    1. Background: Information Security
    2. Experience: CS1010, CS2040C

# Tech Stack
Environment Setup:
1) Visual Studio/ Visual Studio Code
2) SQL Server Management Studio (SSMS)/ Azure Data Studio
    
Azure Services:
1) App Services
2) SQL databases 
3) Key vaults

Technologies:
1) Asp.net Core
2) Blazor Webassembly
3) SignalR
4) Identity Server
5) Entity Framework

# Features and Timeline
A Progressive Web Apps(PWA) provide notification service for tracking orders.

Aim for M1:
 1) Setup Web Service (e.g. WebApp, Sql Server, Key Vault) : Done
 2) Setup Notification (Web notification(android supported, ios by 2023) and Email): Done 
 3) Implement Identity Server for Login: Done
 4) Receipt Generation Dashboard : Done
 
By M2:
 1) Integrate all M1 features into 1 complete app. （Done）

By M3 
 1) Testing
 2) Documentation
 3) Improve on CSS design
 4) Exploring 
      - (Current Pager System + IOT) -> (Extension NFC Smartphone) 
# Service Flowchart
![services](https://user-images.githubusercontent.com/30100720/174736769-633267fb-fed2-4b98-af5c-be35c5625206.png)

# Signal R update Process
![Signal R update Process drawio](https://user-images.githubusercontent.com/30100720/174737788-69279494-1017-4fa7-a3a0-a823804b749e.png)

# Database Schema (Version 0)
![image](https://user-images.githubusercontent.com/30100720/169005025-e57eb7d3-cbe4-4945-ae9f-2e87a2af4a91.png)
