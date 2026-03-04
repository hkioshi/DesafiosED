#include<stdio.h>
#include <stdlib.h>

struct no {
    int info;         
    struct no * prox;
};

struct no * novoNo(int info) {
    struct no * novo = malloc(sizeof(struct no));
    novo->info = info;
    novo->prox = NULL; 
    return novo;
}
struct no * insert_first(struct no * lista, int info) {
    struct no *novo = novoNo(info);
    if (!novo) {
        printf("ERRO AO CRIAR NOVO NO NO INSERT FIRST");
        return lista;
       }   // se falhar, mantém a lista como estava
    novo->prox = lista;        // novo aponta para a antiga cabeça
    return novo;               // novo vira a cabeça
}

void insert_last(struct no * lista, int info) {
    struct no *novo = novoNo(info);
    // Precisamos encontrar o último elemento da lista. Quando encontramos, adicionamos o novo!
    struct no *curr = lista;
    while (curr->prox != NULL) {
        curr = curr->prox;
    }
    curr->prox = novo;
}

struct no * remove_first(struct no * lista) {
    if (lista == NULL) return NULL; // lista vazia

    struct no *novo_inicio = lista->prox;
    return novo_inicio;
}

struct no * reverse_list(struct no * lista)
{
    struct no * novo;
    if(lista-> prox == NULL) return novo;
     
    if(lista-> prox -> prox == NULL)
    {
        return novo = novoNo(lista->prox->info);
    }
    
    novo = novoNo(lista->info);
    for (struct no* curr = lista->prox; curr != NULL; curr = curr->prox)
    {
        novo = insert_first(novo, curr->info );
    }
    return novo;

}

void printList(struct no * lista)
{
    // for (struct no* curr = lista; curr != NULL; curr = curr->prox)
    // {
    //     printf("%d ",curr->info);
    // }

    printf("%d ", lista->info);
    return lista->prox == NULL ? NULL : printList(lista->prox);
    
}

void RemoveUltimo(struct no * lista)
{
    if(lista-> prox == NULL) return ;
    if(lista-> prox -> prox == NULL)
    {
        lista->prox = NULL;
        return;

    }

    struct no *antes = lista;
    
    
    for (struct no* curr = lista->prox->prox; curr != NULL; curr = curr->prox)
    {
       antes = antes->prox;
    }
    
    antes->prox = NULL;
    
    
}

void remove_value(struct no *lista, int value)
{
    for (struct no* curr = lista; curr != NULL; curr = curr->prox)
    {
        if(curr->prox->info == value && lista->prox->prox != NULL)
        {
            curr->prox = curr->prox->prox;
            return;
        }
    }
}



int main() {

    struct no * lista = novoNo(2);
    for (int i = 0; i < 20; i++)
    {
        lista = insert_first(lista, i);
    }
    printList(lista);
    printf("\n");
    struct no * novaLista = reverse_list(lista);
    printList(novaLista);

    
    return 0;
}