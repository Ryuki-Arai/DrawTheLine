# DrawTheLine  
## 概要  
* マウスや画面のタッチ判定を用いて画面上に線を引くやつ

## 開発環境  
* Unity2021.3.4f1  
* Microsoft Visual Stdio 2022  

## 開発方法

__線の引き方__
* LineRendererを使った
  * マウスの判定を取り、生成したオブジェクトにタッチで撮った座標を反映させる
  * 生成時にLineRendererコンポーネントのpositions項目に対する生成時からの経過時間を記録する事で、一定時間後に視点から消えていく様にする

__当たり判定__
* EdgeCollider2Dを使った
  * 線の生成と同時にEdgeCollider2DコンポーネントのPoints項目にも座標を反映させる

_遭遇した問題点_
* 描いた線を始点から消せない問題
  * LineRendererはVector3型配列、EdgeCollider2DはVector2型Listであるため、相互の同期した管理や、LineRendererのPosition配列を先頭から消す方法に苦戦した  
**解決方法 : 線のPoint座標をListとして保持し、精製や抹消をList上で管理、各種項目に反映させることで解決**

* EdgeCollider2Dコンポーネントを使用する際、使用ユーザーのレポートサイトが極端に少なく、些細な不具合の修正に時間を取った
  * 本当に[Unityマニュアル](https://docs.unity3d.com/ja/2019.4/Manual/class-EdgeCollider2D.html)くらいしか引っ掛からない
  * **以下に使用したEdgeCollider2Dの項目をまとめておく**

### EdgeCollider2D まとめ

[EdgeCollider2D概要(本当はこういう使い方らしい)](https://miyagame.net/edgecollider2d/)  
**※EdgeCollider2D同士では衝突判定を取らないので注意**

__本プロジェクトで使用した項目__
1. `float EdgeCollider2D.edgeRadius{get; set;}` : 本コライダーは円形に取られる。そのコライダーの半径を指定する。
2. `bool EdgeCollider2D.SetPoints(List<Vector2> points)` : 当たり判定の頂点座標をまとめて指定する。

__ちょっと ~~ムカついた~~ 使いにくいと思ったところ__
1. 必ずSetPoints関数を呼ばないとColliderが新しく反映されない : 頂点座標(Point)の要素数を更新(減)しても最後にSetPointが呼ばれた状態でモノ言わない。LineRendererでは要素の後ろから消えたのに。
  * 曰く、EdgeCollider2Dはアクセスを受けるたびにその配列が更新される仕組みらしい。

---

## タッチカービィ的なカジュアルゲームの開発  

### ゲーム概要  
* 横スクロール型アクションゲーム  
* ゲーム開始と同時にキャラクターに合わせて画面がスクロールする 
* キャラクターは地面や描かれた線の上を走ることが出来る 
* ゲーム画面に点在するコイン(アイテム)を集めていく 
* 強化アイテムを取るとキャラクターが強化される 
<img width="600" alt="GameScreenMovie2" src="https://github.com/Ryuki-Arai/DrawTheLine/blob/main/Picture_README/Screen_Recording_20220723-161909_DrawTheLine.gif">  


### ゲーム全体の流れ  
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

### 必要な実装  
_キャラクター_  
* ゲームの開始と同時に自動で右に進み続ける  
* 地面や線の上を走り、コインやスターを集める。  
* 様々なスキンがあり、着せ替えが出来る。

_アイテム_
* ゲームシーン上に適当に配置される。
* キャラクターに成長をもたらす。

_コイン_  
* ゲームシーン上に適当に配置される。  
* 集めることでユーザースキンやUIと交換できる。  

_ライン_  
* プレイヤーを誘導するための線。  
* 当たり判定を付ける。  
* 書かれたラインは指定秒後に書いた始点から消えていくようにする。
<img width="600" alt="GameScreenMovie1" src="https://github.com/Ryuki-Arai/DrawTheLine/blob/main/Picture_README/Screen_Recording_20220702-131347_DrawTheLine.gif">

## 遊びの検証1 縦画面モードを作れるか？
**イケた  思ってたよりいい動きした**  
横画面より縦画面の方がハイカジュっぽく見えるのは気のせいだろうか  
アイテムの配置諸々は横画面のを無理矢理縦にしたから、これでやるなら追々調整が必要。  
*こんな感じ*  
<img height="600" alt="GameScreenMovie1" src="https://github.com/Ryuki-Arai/DrawTheLine/blob/main/Picture_README/Screen_Recording_20220812-103919_DrawTheLine.gif">
* 個人的には面白くなりそうだと思った
* ただ、ゲームとするにはまだ課題が多いかも
  * アイテムが一色単なので、もう少し増やすとか
  * [Voodooの「Color Road!」](https://play.google.com/store/search?q=Color%20Road%EF%BC%81&c=apps&hl=ja)  みたいなゲームをイメージすれば面白くなりそう
* このゲームを面白くする要として、__”線を引く”という要素をどう出すか__　という大きな課題が見えた。(横画面の時から意識していたが、改めて実感した)

## 新たな遊びの検証2 ランナーの数を増やすパターン  
**時々考えてた最近のハイカジュに多い形態を検証する**  
動機として、線を引くことに重要度を持たせるにはやはり数なのでは...と思った。  
* 引く線を歪めた時のランナーの波打つ動きや、ランナーの数が増えた時の視覚的効果は面白さに繋がるかも
* 敢えて取りにくい位置にアイテムを置いて、数を増やすことのメリットに繋げる

**サンプル**  
<img width="600" alt="GameScreenMovie2" src="https://github.com/Ryuki-Arai/DrawTheLine/blob/main/Picture_README/Screen_Recording_20220923_125614_DrawTheLine.gif">  

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

## __制作における課題__
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
