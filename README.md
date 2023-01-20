# 線を引く機能を用いたカジュアルゲームの開発  

## 開発環境
* Unity2021.3.4f1  
* Microsoft Visual Stdio 2022  

## ゲーム概要  
* 横スクロール型アクションゲーム  
* ゲーム開始と同時にキャラクターに合わせて画面がスクロールする 
* キャラクターは地面や描かれた線の上を走ることが出来る 
* ゲーム画面に点在するコイン(アイテム)を集めていく 
* 強化アイテムを取るとキャラクターが増殖する  
<img width="600" alt="GameScreenMovie2" src="https://github.com/Ryuki-Arai/DrawTheLine/blob/main/Picture_README/Screen_Recording_20220923_125614_DrawTheLine.gif">  

## ゲーム全体の流れ  
__シーン__  
_●タイトルシーン_  
* ゲーム開始ボタン  
　→ゲームシーンへ
* スキンオプションボタン
  * __選択画面__
* オプションボタン
  * 音量

_●ゲームシーン_  
* 一時停止ボタン
  * 再開ボタン
  * やり直しボタン
  * タイトルへ戻るボタン
* __リザルト画面__
  * 終了ボタン
    →タイトルへ

## 必要な実装  
_キャラクター_  
* ゲームの開始と同時に自動で右に進み続ける  
* 地面や線の上を走り、コインやスターを集める。  
* 様々なスキンがあり、着せ替えが出来る。

_アイテム_
* ゲームシーン上に適当に配置される。
* キャラクターが増殖する。

_コイン_  
* ゲームシーン上に適当に配置される。  
* 集めることでユーザースキンやUIと交換できる。  

_ライン_  
* プレイヤーを誘導するための線。  
* 当たり判定を付ける。  
* 書かれたラインは指定秒後に書いた始点から消えていくようにする。
* **作成した機能は [こちら](https://github.com/Ryuki-Arai/DrawTheLine/wiki)  を参照。**

**課題**  
* 最初のランナーの数をどうするか
  * ランナー同士の当たり判定もつけるか否か
* 道中に設置するランナー増減等のアイテムの仕様をどうするか
  * ここに手を出すと、場合によっては一部アイテムを作り直す必要があるかも???
  * コインは続投でいいかも(+αで頑張りたい人向けの何か)
* 線の描画に制限付けるか否か迷う
  * 完全主観的発想だけど、無限に線を引けた方が楽しかったからそうしたい
  * 無制限だと、フィールドが無法地帯と化しかねないから、いろんな人のフィードバックが必要かも

## ゲームのモチーフを考える
流石にデフォルトのままではリリース出来ないので、ゲーム性を崩すことなくかわいい感じのモチーフを考える
条件的にはこんな感じ？
* 数が増えるんだし、たくさんあって(いて)も違和感ないやつ
* ~~キモくない~~女子供にウケそうなかわいいやつ
* メインと増えたやつの大小関係が分かりやすいやつ

**SNSでカルガモの親子の動画見つけた**  
カルガモだと親子似た見た目でわかりにくいからアヒルの方が視覚的にはいいかな？  
モチーフは鳥類の親子の移動的なヤツにしようと思う

## __制作における課題(書き溜め)__
* **線を引くと何が面白くなるのか？**
  * アイテムを取るたびにプレイヤーが増える → ワタワタ感
  * 障害物をよける線引き → やってはいけないことを避ける
  * ゴールを目指す目標におけるリスクリターン
* ハイカジュにおける制限はあまりよろしくない...？
  * 死の要素は極力なくしたい → 失敗を与えない
  * あくまで必ずクリアできる → ハイスコアを狙いたい人は狙える
* アイテムだけがスコアではない
  * 最終的なゲームのゴールを考える
  * 無段階性のゴール → マリオのゴール旗みたいなもの？
* ギリギリの戦い感を出す
  * ボスを置く → 視覚効果
* **スピード感**
  * 線の上を走ることでスピードアップ → 線を引く意味
* 失敗に対するリスク → **障害物**
* 完璧主義者のための＋α
  * クリアとは別の何か(ハイスコアとかレアアイテムとか)
* **現状のデザインを残すならポイント形式をとる**
  * 昨今のハイカジュによくある形式
* **マップの生成問題**
  * 大量のマップを扱うならば、アイテムの生成方法を考える必要がある。
  * 適当な数のアイテムの配置パターンを作成して、複数のスポーン地点にランダムに出す。
  * ステージごとの難易度をどうするか問題 → とりあえず1(低難易度)と100(高難易度)を作る
    * これらの問題を全て押さえたマップ管理(スポナー)を作る
* **ゲームの広がりを考える**
  * 線を引くギミック(意味合い)の広がり
  * 飽きられないギミック(あそびの幅)を作る
  * スリルを出すには制限がなさすぎる問題
    * スピードを出す、線の描画量に制限を付けるetc.
