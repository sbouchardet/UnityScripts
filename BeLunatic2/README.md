# BeLunatic!2
![alt tag](https://raw.githubusercontent.com/sbouchardet/UnityScripts/master/BeLunatic2/belu.jpg)
> "Apenas busquem conhecimento" <br> - E.T. Belu

<p> Versão 3D do jogo BE LUnatic!. Usando a game engine Unity3D. Nesse repositório temos os scripts de ações do jogo e a instrução de como usa-los. </p>

----
1. **Enemy** </br>
Definimos que os Inimigos basicos do personagem principal tem dois principais comportamentos: *atacar* e *fugir*. </br>
<u>Qualquer herdeiro da classe _Enemy_ tem os seguintes atributos:</u>

  * Action Range </br>
  Distância entre o <u>Player</u> e o <u>Inimigo</u> que ativa a ação do Inimigo.

  * Action Vel  </br>
  Velociadade relativa da ação.

  * Walk Vel </br>
  Velocidade de movimento do inimigo pelos pontos de referência.

  * Rotate Vel </br>
  Velocidade de rotação do inimigo quando se aproxima dos pontos de referência.

  * Points To Walk </br>
  Pontos de referência. É uma lista de GameObject sem colisão que marcam pontos por onde o inimigo deve caminhar. Eles devem ser adicionados na ordem em que serão percorridos.

  Além desses atributos a classe é abstrada e todo herdeiro deve implementar os seguintes métodos:

  - _bool IsActionTime (GameObject Player)_ </br>
  A partir da posição do player relativa ao inimigo, deve conter o seguinte retorno:
    - *true* se a ação deve ser realizada;
    - *false* se a ação não deve ser realizada.

  - _void Action (GameObject Player)_ </br>
  A ação o inimigo deve tomar quando o método IsActionTime(Player) estiver retornando verdadeiro.

  Os hesdeiros dessa classe são **EnemyAttack** e **EnemyRunaway**.
