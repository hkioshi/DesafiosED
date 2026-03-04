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

void printList(struct no * lista)
{
    // for (struct no* curr = lista; curr != NULL; curr = curr->prox)
    // {
    //     printf("%d ",curr->info);
    // }

    printf("%d ", lista->info);
    return lista->prox == NULL ? NULL : printList(lista->prox);
    
}

int main() {

    struct no * lista = novoNo(2);
    for (int i = 0; i < 20; i++)
    {
        lista = insert_first(lista, i);
    }
    
    printList(lista);
    
    return 0;
}