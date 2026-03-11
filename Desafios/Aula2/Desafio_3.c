#include "DesafioBase.c"

void InsereOrdenado(ListaLigada lista, int info)
{
    
    //lista -> inicio -> n1 -> n2 -> null
    //lista -> inicio -> n1* -> n2 -> null
    //lista -> inicio -> n1 -> n2* -> null
    if(lista->inicio == NULL)
    {
        llInsereNoInicio(lista,info);
        return;
    }

    if (info < lista->inicio->info)
    {
        llInsereNoInicio(lista, info);
        return;
    }

    if (info >= lista->fim->info)
    {
        llInsereNoFim(lista, info);
        return;
    }
    for (Celula aux = lista->inicio; aux->prox != NULL ; aux = aux->prox)
    {
        if(aux->prox->info >= info)
        {
            Celula nova = novaCelula(info);
            nova->prox = aux->prox;
            aux->prox = nova;
            return;
        }
    }

    llInsereNoFim(lista, info);

}

int main() {

    srand(time(NULL));
    ListaLigada lista = novaLista();

    for (int i = 0; i < 100; i++) {
        int num = rand() % 100 + 1;

        InsereOrdenado(lista, num);

    }
    llPrint(lista);
   



    return 0;
}