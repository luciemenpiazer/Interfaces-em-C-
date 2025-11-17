# Fase 03 - Interface Plugável e Testável

Nesta fase, realizamos a mudança arquitetural mais importante do projeto: a substituição da classe base abstrata por uma **Interface (`IGeradorMensagem`)** e a introdução de uma classe cliente (`Notificador`) que utiliza **Injeção de Dependência**.

## 1. O que mudou (Herança Rígida → Contrato Flexível)

### Antes (Fase 02)
O código dependia de herança de classes (`extends GeradorMensagem`).
* **Problema:** O cliente precisava conhecer e instanciar as classes concretas (`new PremiumGerador()`). Para testar, não havia como isolar a lógica; éramos obrigados a usar a implementação real.

### Agora (Fase 03)
Introduzimos o conceito de **Contrato**.
* [cite_start]**O Contrato (`interface`):** Define apenas **o que** deve ser feito (`Gerar`), sem dizer **como**[cite: 102].
* **O Cliente (`Notificador`):** Não sabe mais se o usuário é Premium ou Padrão. Ele recebe qualquer objeto que assine o contrato via construtor.

```csharp
[cite_start]// O cliente programa para a interface, não para a implementação [cite: 270-271]
public class Notificador
{
    private readonly IGeradorMensagem _gerador;

    // Recebe a dependência pronta (Injeção de Dependência)
    public Notificador(IGeradorMensagem gerador) 
    {
        _gerador = gerador; 
    }
}
````

## 2\. Conceitos Aplicados

  * **Injeção de Dependência (DI):** Em vez de o `Notificador` criar suas dependências internamente (dando `new`), ele as recebe prontas de fora. [cite\_start]Isso inverte o controle e permite trocar "peças" sem editar a classe do notificador [cite: 108-109].
  * **Testabilidade com Dublês (Stubs):** Como o notificador aceita *qualquer* implementação da interface, criamos um `GeradorDuble`. [cite\_start]Ele é uma classe falsa que retorna um valor fixo, permitindo testar o fluxo do notificador sem depender da lógica complexa de produção [cite: 472-473].

## 3\. Análise de Design

  * **O que melhorou:**

      * **Desacoplamento Total:** Podemos adicionar um `GeradorDeNatal` no futuro e o `Notificador` funcionará sem precisar alterar nenhuma linha de código (respeito ao Princípio Aberto/Fechado - OCP).
      * **Testabilidade:** É possível testar o sistema isoladamente usando stubs, garantindo que o teste seja rápido e determinístico.

  * **Ponto de Atenção:**

      * A responsabilidade de "montar" os objetos (criar as instâncias e injetar) subiu para o `Main`. [cite\_start]Em projetos maiores, isso é gerenciado por containers de DI, mas aqui fizemos manualmente ("Pure DI")[cite: 110, 822].

## 4\. Como Executar

A partir da raiz do repositório, navegue até a pasta da fase e execute:

```bash
cd src/fase-03-com-interfaces
dotnet run
```

## 5\. Evidências de Teste
