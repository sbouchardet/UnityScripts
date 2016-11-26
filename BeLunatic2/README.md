# BeLunatic!2
![alt tag](https://raw.githubusercontent.com/sbouchardet/UnityScripts/master/BeLunatic2/belu.jpg)
> "Apenas busquem conhecimento" <br> - E.T. Belu

<p> Versão 3D do jogo BE LUnatic!. Usando a game engine Unity3D. Nesse repositório temos os scripts de ações do jogo e a instrução de como usa-los. </p>

----
1. **Enemy** </br>
Definimos que os Inimigos básicos do personagem principal tem dois principais comportamentos: *atacar* e *fugir*. </br>
<u>Qualquer herdeiro da classe _Enemy_ tem os seguintes atributos:</u>

  * Action Range </br>
  Distância entre o <u>Player</u> e o <u>Inimigo</u> que ativa a ação do Inimigo.

  * Action Vel  </br>
  Velocidade relativa da ação.

  * Walk Vel </br>
  Velocidade de movimento do inimigo pelos pontos de referência.

  * Rotate Vel </br>
  Velocidade de rotação do inimigo quando se aproxima dos pontos de referência.

  * Points To Walk </br>
  Pontos de referência. É uma lista de GameObject sem colisão que marcam pontos por onde o inimigo deve caminhar. Eles devem ser adicionados na ordem em que serão percorridos.

  Além desses atributos a classe é abstrata e todo herdeiro deve implementar os seguintes métodos:

  - _bool IsActionTime (GameObject Player)_ </br>
  A partir da posição do player relativa ao inimigo, deve conter o seguinte retorno:
    - *true* se a ação deve ser realizada;
    - *false* se a ação não deve ser realizada.

  - _void Action (GameObject Player)_ </br>
  A ação o inimigo deve tomar quando o método IsActionTime(Player) estiver retornando verdadeiro.

  Os herdeiros dessa classe são **EnemyAttack**, **EnemyRunaway** e **EnemyIdle**.

  1. **EnemyAttack**

    * _dashVel_ </br> velocidade de corrida no momento do ataque;

    * _dashRotate_ </br> velocidade de rotação no momento da perseguição.

    * _SecondsBetweenDamages_ </br> tempo em segundos entre o dano causado pelo inimigo quando o player esta no _damageRange_.

    * _damageCoins_ </br> quantidade de moedas no que o player perde por dano desse inimigo.

    * _damageRange_ </br> range em que o inimigo consegue atacar.

  2. **EnemyRunaway**
    * _dashVel_ </br> velocidade de corrida no momento da fulga;

    * _dashRotate_ </br> velocidade de rotação no momento da fulga.

  3. **EnemyIdle**

    Como esse tipo de inimigo não reage a presença do player, então não possui atributos próprios.

2. **Abduction**

  Esse componente deve ser associado ao player, e trata da abdução de inimigos.
>! O inimigo deve estar tageado como `enemy`, se não não será abduzido !
 </br>

 <u>Esse componente tem os seguintes atributos:</u>

  - Abduction Vel </br>
  Velocidade de abdução total.

  - Abduction Ray </br>
  Raio de abdução. Distância máxima que o inimigo pode ficar para poder ser abduzido.

  - Abduction Aproximate Vel </br>
  Velocidade de aproximação do inimigo durante a Abdução.

  - Abduction Min Scale </br>
  Tamanho mínimo que o inimigo atinge durante a abdução.

  - Abduction Laser </br>
  GameObject referente ao Laser de Abdução. O Laser deve estar direcionado como de estivesse abduzindo do eixo `Z` para origem.

  > **Dica**: Se não for possível posicionar naturalmente o GameObject do Laser, o mais fácil é:

  > * criar um <u>GameObject vazio</u>;

  >* posicionar o laser da maneira certa segundo a origem do <u>novo GameObject</u>;

  >* Então colocar o Laser como *filho* do <u>novo GameObject</u>.

  >* Associar ao Atributo Abduction Laser o <u>novo GameObject</u>.

3. **LevelConfig**

  O LevelConfig é o componente de configuração da fase. Seus atributos são:
    * _StartPoint_ </br> GameObject que repesenta o ponto inicial da fase. É usado para definis o local de renacimento do _Player_.

    * _ListOfDemands_
        * _Size_: tamanho da lista de demandas.
        * _Demands_: Cada demanda da lista é um par de informações:
          - Nome do GameObject: nome do objeto que deve ser abduzido como demanda para vitória.
          - Quantidade: quantidade do objeto que deve ser abduzido como demanda para vitória.
4. ** DeadZone **

  Área em que quando o personagem entra ele morre. Deve ser um GameObject tranperente, dentro dos buracos e Água da fase. O componente BoxColider deve ser configurado como na imagem abaixo.

  ![alt tag](https://raw.githubusercontent.com/sbouchardet/UnityScripts/master/BeLunatic2/boxColider_deadZone.png)

5.  ** PlayerStatus **

  Componente que gerencia a vida e as moedas do Player ao longo da fase. Seus atributos são:
  * _StartLife_ </br> quantidade de vidas no início da fase.
	* _StartCoins_ </br> quantidade de moedas no início da fase.
	* _AmountCoinsToNewLife_ </br> quantidade de moedas que devem ser coletadas para se transformarem em uma nova vida. 
