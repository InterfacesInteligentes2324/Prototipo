# Prototipo - Grupo 4
## Interfaces Inteligentes - Curso 2023 - 2024

> Laura Ramallo Pérez
> 
> Adrián Sanz Fernández
> 
> Helena García Díaz

# Introducción

En el presente documento se recoge el trabajo realizado a la hora de desarrollar el prototipo final de la asignatura.

Se trata de un juego de pistas de temática tenebrosa, en el que se debe ir siguiendo indicaciones y realizando tareas, hasta llegar al final del mismo. 

# Modo de uso

El presente juego debe jugarse con mando o teclado, ya que se debe poder controlar el movimiento del jugador y las teclas de acción del juego.

> **Con mando**
> *Teclas de movimiento*: Joystick del mando.
> *Teclas de acción*: Botones del mando.
>
> **Con teclado**
> *Teclas de movimiento*: Flechas de dirección.
> *Teclas de acción*: Letras del teclado.

# Hitos de programación logrados

1. Uso de delegados y eventos a lo largo de todo el juego.
2. Uso de físicas en el juego.
3. Movimiento del jugador.
4. Uso del Google Cardboard para inmersión e interacción con los objetos del entorno.
5. Uso de elementos de audio, así como reconocimiento del habla.
6. Uso de sensores del móvil.

# Funcionamiento de la aplicación

# Acta de trabajo

Para realizar el presente trabajo tuvimos que llegar a una serie de acuerdos. Nos hemos reunido todos en diferentes ocasiones para evaluar el estado del proyecto y los siguientes hitos a cumplir. Así como unir el trabajo que se realizó de manera independiente, comentar los bugs encontrados en el juego, posibles ideas y solución de errores. Del mismo modo, todos hemos colaborado en la elaboración del informe y entrega final de este proyecto.

A parte de eso, nos hemos tenido que coordinar para trabajar de manera asíncrona con los archivos del juego. En cuanto a realización de tareas específicas, podemos identificarlas de esta manera.

#### Adrián

1. Preparación del proyecto inicial, utilizando una escena previa donde el cardboard funcionaba.
2. Lo de las estatuas y los sensores

#### Laura

1. Preparación de la UI de texto para colocar las pistas del usuario.
2. asd
   
#### Helena

1. A partir del proyecto inicial preparado por Adrián, donde ya se incluía la caseta, añadí música cuando se miraba a la pizarra (era una de las pistas para el jugador), lo que en una posterior implementación se cambió a música ambiente durante todo el juego.
2. Movimiento del jugador, con teclado y mando. Para ello utilicé la configuración por defecto que trae Unity, lo que permite detectar los ejes horizontal y vertical a partir de las teclas de dirección del teclado, y del joystick del mando. Luego, realizando transformaciones como en los ejercicios de clase, se implementa una rotación vertical del jugador usando el eje horizontal, y el movimiento hacia atrás y adelante con el eje vertical más la rotación. Además, añadí las teclas del mando en las ya definidas para la interacción con el entorno.
3. Modifiqué también al jugador para que tuviera físicas y no pudiera traspasar las paredes. Esto lo logré cologando un rigidbody y un box collider en el objeto que teníamos para el jugador. En el box collider, modifiqué la mesh del mismo para que estuviera en los pies del jugador. de este modo, es suficiente para que no pueda salir de los recintos, y pueda colisionar con su entorno. También comprobé que en el resto de escenarios, el jugador permanecía dentro de las habitaciones.
4. Adición del hangar. Adrián y yo estuvimos buscando diferentes modelos en la AssetStore y encontramos este que era un espacio amplio que nos permitía hacer las ideas que teníamos, además de que pesaba poco. Al principio el jugador podía traspasar las paredes, con lo que creé un objeto vacío de paredes, y fui añadiendo objetos con rigidbodies y boxcolliders, y los modifiqué para que coincidienran con las paredes pero no se chocaran entre sí.
5. Busqué un objeto de maleta en la AssetStore y le añadí un rigidbody y le ajusté un boxcollider, para que el jugador pudiera chocar con ella. Además, le añadí un script utilizando delegados y eventos, para que cuando detectara una colisión con el jugador, lo notificara como que se había recogido una maleta, y desactivara el objeto. De esta manera, en el controlador del texto, se recibe este mensaje y se va aumentando el contador de maletas recogidas.
