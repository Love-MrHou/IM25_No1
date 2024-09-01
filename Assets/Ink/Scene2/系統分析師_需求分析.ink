大家好，感謝各位今天來參加我們的需求分析會議。今天的目的是了解各位公司對於IG社群軟體廣告投放的需求。我們會進行詳細的討論，以便制定出最適合的廣告策略。請先簡單介紹一下各自公司的背景和目前的需求。
GreenVital Foods代表：我們是 GreenVital Foods，專注於健康食品的生產和銷售。我們希望通過IG提升品牌知名度，特別是在年輕消費群體中。我們有100,000美元的預算，目標是六個月內提升品牌認知度20%。
Elegance Accessories代表：我們是Elegance Accessories，專注於高端時尚配件。我們希望吸引更多高端消費者，尤其是25-35歲的女性。預算是150,000美元，目標是三個月內提高線上銷售量10%。
TechNova代表：我們是TechNova，主要從事電子產品。我們希望通過IG來推廣我們的新產品系列，目標受眾是科技愛好者和年輕人群。預算是120,000美元，目標是四個月內提升網站流量25%。
TravelNest代表：我們是TravelNest，經營旅遊服務。我們希望利用IG來宣傳我們的新旅遊套餐，特別是在有家庭的受眾中。預算是80,000美元，目標是三個月內增加預訂量15%。
EcoEssentials代表：我們是EcoEssentials，專注於環保產品。我們希望提升品牌的綠色形象，吸引注重環保的消費者。預算是70,000美元，目標是五個月內提升品牌忠誠度20%。
->analysis
VAR choiceA1_done = false
VAR choiceA2_done = false
VAR choiceA3_done = false

VAR choiceB1_done = false
VAR choiceB2_done = false
VAR choiceB3_done = false

VAR choiceC1_done = false
VAR choiceC2_done = false
VAR choiceC3_done = false

VAR choiceD1_done = false
VAR choiceD2_done = false
VAR choiceD3_done = false

VAR choiceE1_done = false
VAR choiceE2_done = false
VAR choiceE3_done = false

===analysis===
{(choiceA1_done || choiceA2_done || choiceA3_done) && (choiceB1_done || choiceB2_done || choiceB3_done) && (choiceC1_done || choiceC2_done || choiceC3_done) && (choiceD1_done || choiceD2_done || choiceD3_done) && (choiceE1_done || choiceE2_done || choiceE3_done):
    * [總結與分析] -> summaryAndAnalysis
}
* [GreenVital Foods的需求分析] -> companyA
* [Elegance Accessories的需求分析] -> companyB
* [TechNova的需求分析] -> companyC
* [TravelNest的需求分析] -> companyD
* [EcoEssentials的需求分析] -> companyE

    
=== companyA ===
{choiceA1_done || choiceA2_done || choiceA3_done:
    * [進行其他公司分析] 返回選擇 -> analysis
}
*[可以請您詳細說明一下目前的市場定位和主要競爭對手嗎？]{not choiceA1_done} ->choiceA1
*[您提到的年輕人群體，具體是指哪個年齡段？] {not choiceA2_done} ->choiceA2
*[除了品牌知名度提升，您有沒有其他的次要目標，比如銷售轉化或網站流量增加？]{not choiceA3_done} ->choiceA3

=== choiceA1 ===
GreenVital Foods代表：我們的主要市場定位是健康和有機食品，我們的競爭對手主要是一些大型連鎖超市和專賣店。
系統分析師：了解了。您是否有具體的創意或內容風格？
GreenVital Foods代表：我們的品牌主要圍繞健康和自然的生活方式。我們希望通過簡約而清新的視覺風格來傳達這個理念。在內容上，我們打算強調產品的天然成分和健康益處，並結合一些使用場景，比如運動後的健康飲品或是快速的營養餐點。我們也考慮邀請一些健康生活方式的影響者來合作，進一步增強品牌形象。
* [返回] 返回選擇 -> returnFromChoiceA1
//* [返回其他公司分析] -> analysis    

=== choiceA2 ===
GreenVital Foods代表：我們主要針對18-35歲之間的年輕人，這些人群對健康食品有較高的興趣。
系統分析師：您是否已經嘗試過其他的廣告平台？效果如何？
GreenVital Foods代表：是的，我們之前在Facebook和Google Ads上做過一些廣告投放。整體來說，Facebook上的廣告效果還不錯，特別是在提升品牌關注度方面。我們的粉絲數和網站流量都有所增加。Google Ads的效果主要體現在搜索廣告上，幫助我們在潛在客戶搜索相關產品時獲得更高的曝光率。不過，我們發現這些平台的年輕用戶參與度有限，因此希望通過IG吸引更多年輕群體。
* [返回] 返回選擇 -> returnFromChoiceA2
//* [返回其他公司分析] -> analysis 

=== choiceA3 ===
GreenVital Foods代表：除了品牌知名度提升，我們也希望通過促銷活動增加產品的銷售轉化。
系統分析師：在預算方面，您希望如何分配這100,000美元？
GreenVital Foods代表：我們計劃將預算分配為三個部分：首先，30%用於廣告創意和製作，包括圖片、短視頻等。其次，50%用於IG上的廣告投放，主要針對年輕消費群體。我們打算使用動態廣告、故事廣告等形式來提升互動性。最後，20%用於與影響者的合作，選擇與我們品牌理念契合的影響者，進行定向推廣。這樣的分配方式可以確保我們在創意、投放和推廣上都能有所保障。
* [返回] 返回選擇 -> returnFromChoiceA3
//* [返回其他公司分析] -> analysis 
    
=== returnFromChoiceA1 ===
~ choiceA1_done = true
-> companyA

=== returnFromChoiceA2 ===
~ choiceA2_done = true
-> companyA

=== returnFromChoiceA3 ===
~ choiceA3_done = true
-> companyA    



=== companyB ===
{choiceB1_done || choiceB2_done || choiceB3_done:
    * [進行其他公司分析] 返回分析 -> analysis
}
* [您目前主要使用哪些渠道來推廣產品？] {not choiceB1_done} -> choiceB1
* [在IG上的廣告內容方面，您有什麼具體的創意或風格嗎？] {not choiceB2_done} -> choiceB2
* [除了線上銷售提升，您有沒有其他考慮的目標，比如增加社交媒體的關注度？] {not choiceB3_done} -> choiceB3

=== choiceB1 ===
Elegance Accessories代表：我們目前主要使用時尚雜誌和合作網紅來推廣產品。
系統分析師：這樣看來，您對品牌形象的維護非常重視。我們可以考慮與高端影響者合作。
Elegance Accessories代表：沒錯，我們對品牌形象的維護非常看重。高端影響者的粉絲群體通常對品質和時尚有較高的要求，他們的推薦能夠有效提升我們的品牌價值。我們已經有一些合作夥伴，但希望能夠拓展更多與我們品牌調性一致的影響者。這些影響者可以通過展示我們的產品與他們的日常生活相結合，來強調我們產品的優雅和時尚感。此外，我們也會考慮與時尚博客或時尚雜誌進行合作，進一步擴大品牌的影響力。
* [返回] 返回選擇 -> returnFromChoiceB1
//* [返回其他公司分析] -> analysis  

=== choiceB2 ===
Elegance Accessories代表：我們希望在IG上呈現出高端和精緻的風格，與我們的品牌形象一致。
系統分析師：您是否有過使用UGC（用戶生成內容）來推廣的經驗？
Elegance Accessories代表：我們確實嘗試過一些UGC的活動，比如舉辦競賽鼓勵消費者分享他們佩戴我們配件的照片和視頻。我們發現這種方式不僅可以增加品牌的曝光率，還能提升顧客的參與感和忠誠度。我們的消費者往往對我們的產品有很強的認同感，他們樂於分享自己的搭配創意。我們計劃在未來加大這方面的投入，例如通過使用特定的主題標籤來收集UGC，並選出優秀的作品進行展示。
* [返回] 返回選擇 -> returnFromChoiceB2
//* [返回其他公司分析] -> analysis  

=== choiceB3 ===
Elegance Accessories代表：我們也希望通過這次投放增加我們的IG粉絲數量和社交媒體互動。
系統分析師：在內容創作上，您是否有特別希望突出的產品特色或信息？
Elegance Accessories代表：我們的產品主要強調的是高品質的材料和精湛的工藝。我們希望在廣告中突出這些特點，讓消費者感受到我們產品的高端和奢華。具體來說，我們的配件選用的是純銀、黃金和珍珠等珍貴材料，並且每件產品都是由經驗豐富的工匠手工製作的。我們想要通過精美的視覺呈現和細膩的產品細節展示，讓消費者感受到我們產品的獨特性和價值。我們也會強調產品的設計靈感和創作過程，以增加消費者對品牌的情感連結。
* [返回] 返回選擇 -> returnFromChoiceB3
//* [返回其他公司分析] -> analysis  

=== returnFromChoiceB1 ===
~ choiceB1_done = true
-> companyB

=== returnFromChoiceB2 ===
~ choiceB2_done = true
-> companyB

=== returnFromChoiceB3 ===
~ choiceB3_done = true
-> companyB
 
 
 
=== companyC ===
{choiceC1_done || choiceC2_done || choiceC3_done:
    * [進行其他公司分析] 返回分析 -> analysis
}
* [您對於新產品的市場期待如何？] {not choiceC1_done} -> choiceC1
* [是否有特定的特徵或功能是您希望強調的？] {not choiceC2_done} -> choiceC2
* [您希望廣告投放的頻率和內容長度如何？] {not choiceC3_done} -> choiceC3

=== choiceC1 ===
TechNova代表：我們對新產品寄予厚望，特別是因為它的創新性。
系統分析師：您對於使用動態廣告是否有興趣？這能夠更好地展示產品的性能。
TechNova代表：我們對動態廣告非常感興趣，特別是能夠展示產品性能的短視頻或動畫。這些廣告形式能夠生動地演示我們產品的功能，如高性能處理器的速度、智能功能的應用場景等。我們相信，通過動態廣告，我們能更有效地傳達產品的價值和優勢，讓消費者在短時間內對我們的產品留下深刻印象。我們希望製作一些具有吸引力的動畫或使用案例演示，並將其在社交媒體和視頻平台上廣泛推廣。
* [返回] 返回選擇 -> returnFromChoiceC1
//* [返回其他公司分析] -> analysis  

=== choiceC2 ===
TechNova代表：我們希望突出產品的高性能和智能功能。
系統分析師：是否有特定的競爭對手或市場趨勢是您關注的？
TechNova代表：我們非常關注高科技市場中的競爭對手，特別是那些同樣致力於智能設備和高性能產品的公司。這些競爭對手通常擁有強大的品牌影響力和技術實力，因此我們需要通過差異化來突出我們的產品。我們的策略之一是強調我們產品的獨特創新點，比如更加智能化的功能和更優秀的性能表現。我們也密切關注市場趨勢，例如智能家居設備的增長趨勢，我們希望在這些新興領域中搶占先機。
* [返回] 返回選擇 -> returnFromChoiceC2
//* [返回其他公司分析] -> analysis  

=== choiceC3 ===
TechNova代表：我們傾向於頻繁的短視頻投放，以保持消費者的興趣。
系統分析師：您對於廣告的轉化目標有什麼具體的數據或預期嗎？
TechNova代表：我們的目標是將廣告的轉化率提升至目前的兩倍。具體來說，我們希望在接下來的四個月內，通過廣告推廣將網站訪客轉化為實際購買者的比例提升到10%。我們計劃通過精準的目標定位、吸引人的創意內容，以及針對特定受眾群體的定向廣告來達成這個目標。我們還將利用數據分析工具來追蹤廣告效果，並根據數據及時調整策略，以確保我們的投資能夠帶來最佳的回報。
* [返回] 返回選擇 -> returnFromChoiceC3
//* [返回其他公司分析] -> analysis  

=== returnFromChoiceC1 ===
~ choiceC1_done = true
-> companyC

=== returnFromChoiceC2 ===
~ choiceC2_done = true
-> companyC

=== returnFromChoiceC3 ===
~ choiceC3_done = true
-> companyC



=== companyD ===
{choiceD1_done || choiceD2_done || choiceD3_done:
    * [進行其他公司分析] 返回分析 -> analysis
}
*[您對於旅遊套餐的市場期待如何？] {not choiceD1_done} -> choiceD1
*[是否有特定的活動或服務是您希望強調的？] {not choiceD2_done} -> choiceD2
*[希望廣告投放的頻率和內容長度如何？] {not choiceD3_done} -> choiceD3

=== choiceD1 ===
TravelNest代表：我們希望通過這次推廣，能夠吸引更多家庭和中高收入群體來選擇我們的旅遊套餐。
系統分析師：您對於與旅遊博主合作製作深度體驗影片是否有興趣？
TravelNest代表：我們非常有興趣與旅遊博主合作，特別是那些能夠提供深度體驗報導的博主。我們認為這些深度影片可以更好地展示我們的旅遊套餐特色，讓觀眾親身感受到我們提供的獨特體驗。博主可以介紹我們的高端住宿、精緻餐飲和家庭友好的活動安排，並且展示旅程中的亮點和細節。這不僅能增加品牌的真實感，還能通過博主的個人影響力吸引更多的目標受眾。
* [返回] 返回選擇 -> returnFromChoiceD1
//* [返回其他公司分析] -> analysis  

=== choiceD2 ===
TravelNest代表：我們的套餐強調豪華住宿、精緻餐飲以及適合全家人的娛樂活動，這些都是我們的核心賣點。
系統分析師：您是否有特別關注的旅遊市場趨勢？例如，冒險旅遊或生態旅遊？
TravelNest代表：我們特別關注幾個主要的旅遊市場趨勢，包括冒險旅遊和生態旅遊。隨著人們越來越重視環保和可持續發展，生態旅遊正在成為一個重要的市場。我們的許多旅遊套餐都包含生態旅遊元素，例如參觀自然保護區、參與環保活動等。此外，我們也看到了冒險旅遊的增長趨勢，因此我們提供的套餐中包含一些如山地探險、潛水等活動，滿足追求刺激和挑戰的客戶需求。

* [返回] 返回選擇 -> returnFromChoiceD2
//* [返回其他公司分析] -> analysis  

=== choiceD3 ===
TravelNest代表：我們計劃投放一系列短視頻，每週兩到三次，展示不同的旅遊場景和活動，以保持受眾的興趣。
系統分析師：您對於預訂量增加的目標有什麼具體的數字預期嗎？
TravelNest代表：我們的目標是在接下來的三個月內，將預訂量提高15%。這個目標是基於我們目前的市場分析和預測設定的。我們認為通過精準的廣告投放和優質的內容展示，特別是強調我們的家庭友好和多樣化選擇，我們能夠達到這個目標。我們也會密切關注市場反應和客戶反饋，隨時調整我們的推廣策略，以確保能夠吸引更多的預訂。
* [返回] 返回選擇 -> returnFromChoiceD2
//* [返回其他公司分析] -> analysis  

=== returnFromChoiceD1 ===
~ choiceD1_done = true
-> companyD

=== returnFromChoiceD2 ===
~ choiceD2_done = true
-> companyD

=== returnFromChoiceD3 ===
~ choiceD3_done = true
-> companyD



=== companyE ===
{choiceE1_done || choiceE2_done || choiceE3_done:
    * [進行其他公司分析] 返回分析 -> analysis
}
*[您對於提升品牌綠色形象的市場期待如何？] {not choiceE1_done} -> choiceE1
*[是否有特定的產品特點或環保理念是您希望強調的？] {not choiceE2_done} -> choiceE2
*[您希望廣告投放的頻率和內容長度如何？] {not choiceE3_done} -> choiceE3

=== choiceE1 ===
EcoEssentials代表：我們希望這次推廣能夠提升我們品牌的知名度，特別是在環保和可持續產品市場中。
系統分析師：您對於展示實際的環保成果或支持的環保組織是否感興趣？
EcoEssentials代表：我們非常感興趣展示我們在環保方面取得的實際成果。我們的產品使用可再生材料，並且我們在生產過程中積極採取措施降低碳足跡。我們希望通過展示這些努力，讓消費者了解我們在環保方面的堅持與貢獻。我們也支持多個環保組織，並參與各類環保活動，例如海洋清理和森林保護。我們計劃在廣告內容中加入這些活動的影像和數據，以增加品牌的可信度和吸引力。
* [返回] 返回選擇 -> returnFromChoiceE1
//* [返回其他公司分析] -> analysis  

=== choiceE2 ===
EcoEssentials代表：我們的產品主要強調環保材料和低碳生產過程，這是我們希望消費者能夠了解到的關鍵信息。
系統分析師：您有考慮過與環保主題的影響者或組織合作來推廣嗎？
EcoEssentials代表：是的，我們認為與環保主題的影響者和組織合作是非常有效的推廣方式。這些影響者通常擁有一群高度忠誠且關注環保議題的粉絲，我們的產品理念與他們的價值觀非常一致。我們希望通過這些合作，讓更多消費者了解我們的品牌和產品，並進一步擴大我們的影響力。我們也在尋找與環保組織合作的機會，通過共同推動環保項目，來提升我們在市場中的地位和認可度。
* [返回] 返回選擇 -> returnFromChoiceE2
//* [返回其他公司分析] -> analysis  

=== choiceE3 ===
EcoEssentials代表：我們計劃每週投放兩到三次的短視頻，展示我們的產品故事和環保理念，內容會側重於我們的生產流程和材料選擇。
系統分析師：您對於提升品牌忠誠度有什麼具體的數據目標或預期嗎？
EcoEssentials代表：我們的目標是在未來五個月內將品牌忠誠度提升20%。這個數據目標是基於我們目前的顧客調查和市場分析得出的。我們計劃通過加強與現有客戶的互動，提供優質的客戶服務，以及推出會員獎勵計劃來達成這個目標。此外，我們也會繼續推廣我們的環保理念和成果，並邀請消費者參與我們的環保活動。我們相信這樣的策略能夠加強顧客對我們品牌的認同感，從而提高品牌忠誠度。
* [返回] 返回選擇 -> returnFromChoiceE3
//* [返回其他公司分析] -> analysis  

===returnFromChoiceE1===
~ choiceE1_done = true
-> companyE

===returnFromChoiceE2===
~ choiceE2_done = true
-> companyE

===returnFromChoiceE3===
~ choiceE3_done = true
-> companyE    



=== summaryAndAnalysis ===
系統分析師：根據收集到的需求和目標，我們將分析這些數據，並制定出最有效的廣告策略。感謝各位的詳細介紹和分享。
系統分析師：現在是決策時刻，我需要考慮每個公司的需求、預算和目標，並選擇最合適的廣告策略。

* [選擇 GreenVital Foods，因為他們的目標受眾和IG用戶群體高度吻合，而且健康食品市場有巨大的潛力。] -> companyAChosen
* [選擇 Elegance Accessories，因為他們的高端品牌定位能夠通過精緻的廣告風格吸引目標消費者。] -> companyBChosen
* [選擇 TechNova，他們的新產品具有創新性，市場潛力大，且目標明確。] -> companyCChosen
* [選擇 TravelNest，他們的旅遊服務需要在家庭市場上擴展，而這個市場在IG上活躍。] -> companyDChosen
* [選擇 EcoEssentials，因為環保產品和綠色品牌形象符合現代消費者的價值觀，並且IG上有很多環保主題的社群。] -> companyEChosen


=== companyAChosen ===
系統分析師：根據我們的分析，最終建議是與 GreenVital Foods 合作，因為他們的需求和目標與我們的廣告策略高度契合。
公司代表：感謝您的詳細分析和建議，我們會根據您的方案進行下一步的合作計劃。
系統分析師：感謝大家的參與，今天的會議到此結束。我們會在之後提供詳細的廣告計劃報告，再次感謝大家。

* [完成] -> END

=== companyBChosen ===
系統分析師：根據我們的分析，最終建議是與 Elegance Accessories 合作，因為他們的需求和目標與我們的廣告策略高度契合。
公司代表：感謝您的詳細分析和建議，我們會根據您的方案進行下一步的合作計劃。
系統分析師：感謝大家的參與，今天的會議到此結束。我們會在之後提供詳細的廣告計劃報告，再次感謝大家。

* [完成] -> END

=== companyCChosen ===
系統分析師：根據我們的分析，最終建議是與公司 TechNova 合作，因為他們的需求和目標與我們的廣告策略高度契合。
公司代表：感謝您的詳細分析和建議，我們會根據您的方案進行下一步的合作計劃。
系統分析師：感謝大家的參與，今天的會議到此結束。我們會在之後提供詳細的廣告計劃報告，再次感謝大家。

* [完成] -> END

=== companyDChosen ===
系統分析師：根據我們的分析，最終建議是與公司 TravelNest 合作，因為他們的需求和目標與我們的廣告策略高度契合。
公司代表：感謝您的詳細分析和建議，我們會根據您的方案進行下一步的合作計劃。
系統分析師：感謝大家的參與，今天的會議到此結束。我們會在之後提供詳細的廣告計劃報告，再次感謝大家。

* [完成] -> END

=== companyEChosen ===
系統分析師：根據我們的分析，最終建議是與 EcoEssentials 合作，因為他們的需求和目標與我們的廣告策略高度契合。
公司代表：感謝您的詳細分析和建議，我們會根據您的方案進行下一步的合作計劃。
系統分析師：感謝大家的參與，今天的會議到此結束。我們會在之後提供詳細的廣告計劃報告，再次感謝大家。

* [完成] -> END
