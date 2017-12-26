namespace Teste_CRUD_CiaTecnica.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CodeFirst : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "SYSTEM.Pessoa",
                c => new
                    {
                        PessoaId = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        Logradouro = c.String(nullable: false, maxLength: 100, unicode: false),
                        Numero = c.Decimal(nullable: false, precision: 10, scale: 0),
                        Complemento = c.String(maxLength: 50, unicode: false),
                        Bairro = c.String(nullable: false, maxLength: 100, unicode: false),
                        Cidade = c.String(nullable: false, maxLength: 100, unicode: false),
                        CEP = c.String(nullable: false, maxLength: 8, unicode: false),
                        UF = c.String(nullable: false, maxLength: 2, unicode: false),
                        TipoPessoa = c.String(nullable: false, maxLength: 8, unicode: false),
                    })
                .PrimaryKey(t => t.PessoaId);
            
            CreateTable(
                "SYSTEM.PessoaFisica",
                c => new
                    {
                        PessoaId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        CPF = c.String(nullable: false, maxLength: 14, unicode: false),
                        DataNascimento = c.DateTime(nullable: false),
                        Sobrenome = c.String(nullable: false, maxLength: 15, unicode: false),
                    })
                .PrimaryKey(t => t.PessoaId)
                .ForeignKey("SYSTEM.Pessoa", t => t.PessoaId)
                .Index(t => t.PessoaId)
                .Index(t => t.CPF, unique: true, name: "UN_PessoaFisica_CPF");
            
            CreateTable(
                "SYSTEM.PessoaJuridica",
                c => new
                    {
                        PessoaId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        CNPJ = c.String(nullable: false, maxLength: 18, unicode: false),
                        NomeFantasia = c.String(nullable: false, maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.PessoaId)
                .ForeignKey("SYSTEM.Pessoa", t => t.PessoaId)
                .Index(t => t.PessoaId)
                .Index(t => t.CNPJ, unique: true, name: "UN_PessoaJuridica_CNPJ");
            
        }
        
        public override void Down()
        {
            DropForeignKey("SYSTEM.PessoaJuridica", "PessoaId", "SYSTEM.Pessoa");
            DropForeignKey("SYSTEM.PessoaFisica", "PessoaId", "SYSTEM.Pessoa");
            DropIndex("SYSTEM.PessoaJuridica", "UN_PessoaJuridica_CNPJ");
            DropIndex("SYSTEM.PessoaJuridica", new[] { "PessoaId" });
            DropIndex("SYSTEM.PessoaFisica", "UN_PessoaFisica_CPF");
            DropIndex("SYSTEM.PessoaFisica", new[] { "PessoaId" });
            DropTable("SYSTEM.PessoaJuridica");
            DropTable("SYSTEM.PessoaFisica");
            DropTable("SYSTEM.Pessoa");
        }
    }
}
