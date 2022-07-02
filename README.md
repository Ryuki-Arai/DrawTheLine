# DrawTheLine  
## 概要  
* マウスを用いて画面上に線を引くやつを作る
* それを使ってゲームを作る
* _スマートフォン向けスクロールアクション_

## 開発環境  
* Unity2021.3.4f1  
* Microsoft Visual Stdio 2022  

## タッチカービィ的なカジュアルゲームの開発  

__ゲーム概要__  

* 横スクロール型アクションゲーム  
* ゲーム開始と同時にキャラうたーに合わせて画面がスクロールする ![GameScreenImage1](https://github.com/Ryuki-Arai/DrawTheLine/blob/main/Picture_README/Screenshot_20220702-160153_DrawTheLine.jpg "GameScreenImage1")  
* キャラクターは地面や描かれた線の上を走れる ![GameScreenImage2](https://github.com/Ryuki-Arai/DrawTheLine/blob/main/Picture_README/Screenshot_20220702-160212_DrawTheLine.jpg "GameScreenImage2")  
* ゲーム画面に点在するコイン(アイテム)を集めていく ![GameScreenImage3](https://github.com/Ryuki-Arai/DrawTheLine/blob/main/Picture_README/Screenshot_20220702-160204_DrawTheLine.jpg "GameScreenImage3")  

__必要な実装__  

_プレイヤー_  
* ゲームの開始と同時に右に進み続ける  
* 地面や線の上を走り、コインやスターを集める。  

_スター_
* 各ステージのスコアとなる。
* ゲームシーン上に3つ配置される。

_コイン_  
* ゲームシーン上に適当に配置される。  
* このコインを集めると、ユーザースキンやUIと交換できる。  

_ライン_  
* プレイヤーを誘導するための線。  
* 当たり判定を付ける。  
* 書かれたラインは指定秒後に書いた始点から消えていくようにする。
![GameScreenMovie1](https://github.com/Ryuki-Arai/DrawTheLine/blob/main/Picture_README/Screen_Recording_20220702-131347_DrawTheLine.gif "GameScreenMovie1")  
