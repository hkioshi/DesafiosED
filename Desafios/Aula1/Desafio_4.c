#include<stdio.h>
#include <stdlib.h>
#include "DesafioBase.c"


struct no * reverse_list(struct no * lista)
{
    //Se a lista tiver apenas um elemento, retorna a nova lista
    //Se a lista tiver exatamente dois elementos, cria um novo nó com o valor do segundo elemento (que será o primeiro na invertida)
    //Caso tenha mais elementos, cria o primeiro nó da nova lista com o valor do primeiro elemento da lista original
    //Percorre o restante da lista original
    // Insere cada elemento no início da nova lista
    //Ao final, retorna a nova lista invertida
    
    struct no * novo;
    if(lista->prox == NULL) return novo;
     
    if(lista->prox->prox == NULL)
    {
        return novo = novoNo(lista->prox->info);
    }
    
    novo = novoNo(lista->info);

    for (struct no* curr = lista->prox; curr != NULL; curr = curr->prox)
    {
        novo = insert_first(novo, curr->info);
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

int main() 
{

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