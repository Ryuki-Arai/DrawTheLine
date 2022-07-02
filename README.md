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
<font color="Red">EdgeCollider2D同士では衝突判定を取らないので注意！</font>

__本プロジェクトで使用した項目__
1. `float EdgeCollider2D.edgeRadius{get; set;}` : 本コライダーは円形に取られる。そのコライダーの半径を指定する。
2. `bool EdgeCollider2D.SetPoints(List<Vector2> points)` : 当たり判定の頂点座標をまとめて指定する。

__ちょっと ~~ムカついた~~ 使いにくいと思ったところ__
1. 必ずSetPoints関数を呼ばないとColliderが新しく反映されない : 頂点座標(Point)の要素数を更新(減)しても最後にSetPointが呼ばれた状態でモノ言わない。LineRendererでは要素の後ろから消えたのに。
  * 曰く、EdgeCollider2Dはアクセスを受けるたびにその配列が更新される仕組みらしい。

---

## タッチカービィ的なカジュアルゲームの開発  

__ゲーム概要__  

* 横スクロール型アクションゲーム  
* ゲーム開始と同時にキャラうたーに合わせて画面がスクロールする <img width="600" alt="GameScreenImage1" src="https://github.com/Ryuki-Arai/DrawTheLine/blob/main/Picture_README/Screenshot_20220702-160153_DrawTheLine.jpg">  
* キャラクターは地面や描かれた線の上を走ることが出来る <img width="600" alt="GameScreenImage2" src="https://github.com/Ryuki-Arai/DrawTheLine/blob/main/Picture_README/Screenshot_20220702-160212_DrawTheLine.jpg">  
* ゲーム画面に点在するコイン(アイテム)を集めていく <img width="600" alt="GameScreenImage3" src="https://github.com/Ryuki-Arai/DrawTheLine/blob/main/Picture_README/Screenshot_20220702-160204_DrawTheLine.jpg">  

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
<img width="600" alt="GameScreenMovie1" src="https://github.com/Ryuki-Arai/DrawTheLine/blob/main/Picture_README/Screen_Recording_20220702-131347_DrawTheLine.gif">


__制作における課題__
* 線を引くと何が面白くなるのか？
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
* 失敗に対するリスク → **障害物**
* 完璧主義者のための＋α
  * クリアとは別の何か(ハイスコアとかレアアイテムとか)
* **現状のデザインを残すならポイント形式をとる**
  * 昨今のハイカジュによくある形式
