#include "DesafioBase.c"

//Faça o algoritmo de bubbleSort usando listas ligadas. Sua função deve receber uma lista ligada e então ordená-la usando bubbleSorte

int SizeOf(ListaLigada lista)
{
    int count = 0;
    for (Celula aux = lista->inicio; aux != NULL; aux = aux->prox) {
        count++;
    }
    return count;
}

Celula get(ListaLigada lista, int pos)
{
     int count = -1;
    for (Celula aux = lista->inicio; aux != NULL; aux = aux->prox) {
        count++;
        if(count == pos)
            return aux;
    }
    
}

void bubbleSort(ListaLigada lista, int n) {
 
    Celula aux = lista->inicio;

    for(int i = 0; i < n - 1; i++) {
        for (int j = 0; j < n - 1 - i; j++) {
            if (aux->info > aux->prox->info) 
            {
                int temp = aux->info;
                aux->info = aux->prox->info;
                aux->prox->info = temp;
            }
            aux = aux->prox;
        }
            aux = lista->inicio;
    }
}

int main() {
    ListaLigada lista = novaLista();

     for (int i = 1; i <= 20; i++) {
        llInsereNoFim(lista, i);
        llInsereNoInicio(lista,i);
    }

    bubbleSort(lista, SizeOf(lista));
    
    llPrint(lista);

    return 0;
}