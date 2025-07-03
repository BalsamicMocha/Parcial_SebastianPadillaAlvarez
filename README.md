# Parcial\_SebastianPadillaAlvarez

Parcial programacion 2 4to tetra, juego 3
Apunta con el mouse/pluma

Haz click sobre el mesh para destruir un objeto, sumar un punto y recuperar tiempo de juego



Para modificar el intervalo entre spawns, dentro de "Managers" en la jerarquia haz click en SpawnManager y en el inspector modifica "Min Delay"/"Max Delay"

Ahi mismo se puede modificar el prefab del objetivo, solo tener en cuenta que el area de spawn se tomo en cuenta el tamanio del gustambo para que no se pudiese salir parte de su modelo de la pantalla.

Tambien se puede modificar el tamanio del pool aunque con 10 deberia ser mas que suficiente, aumentar en caso de subir demasiado el tiempo de vida maximo del objetivo.



Tambien dentro de "Managers" si se selecciona GameManager en el inspector se puede modificar el tiempo inicial.



En Assets/GAME/3D/PREFABS sale Gustambito el prefab del objetivo, al hacer click sobre el se pueden modificar los siguientes parametros en el inspector:



Tiempo de vida minimo, tiempo de vida maximo



Cantidad de puntos que da cada objetivo eliminado



Cantidad de tiempo que suma al tiempo de juego al eliminar cada objetivo

