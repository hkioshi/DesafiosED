#include "DesafioBase.c"


//Implementa a função somaLista, que recebe uma lista ligada e retorna a soma da mesma
void somaLista(ListaLigada lista)
{
    //A funcao vai iterar por todos as celulas e somando suas infos
    int soma = 0;
    for (Celula aux = lista->inicio; aux != NULL; aux = aux->prox) {
        soma += aux->info;
    }
    printf("A soma é: %d", soma);
}


int main() {
    ListaLigada lista = novaLista();

    for (int i = 1; i <= 5; i++) {
        llInsereNoFim(lista, i);
        llInsereNoInicio(lista,i);
    }
    llPrint(lista);
    somaLista(lista);
    
    

    return 0;
}