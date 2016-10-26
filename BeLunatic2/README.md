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

  Os herdeiros dessa classe são **EnemyAttack** e **EnemyRunaway**.

2. **Abduction** </br>
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
