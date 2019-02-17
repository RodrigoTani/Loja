﻿using Dominio;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loja.Models
{
    public class EstoqueProdutos : EntidadeDominio
    {
        [ForeignKey("AdicionarJogo")]
        public int Jogo { get; set; }
         
        [Required]
        [Display(Name = "Porcentagem de precificação do Jogo")]
        public Decimal PorcentagemPrecificacao { get; set; }

        [ForeignKey("fornecedor")]
        public int Fornecedor { get; set; }

        [Required(ErrorMessage = "O custo de compra do Jogo é necessário")]
        [Display(Name = "Custo do Jogo")]
        [DataType(DataType.Currency)]
        public Decimal Custo { get; set; }

        [Required(ErrorMessage = "A quantidade deve ser informada")]
        [Display(Name = "Quantidade")]
        public int Quantidade { get; set; }

        public bool Ativo { get; set; } = true;

        //Auxiliares

        public virtual Fornecedor fornecedor { get; set; }
        public virtual AdicionarJogo AdicionarJogo { get; set; }
    }
}