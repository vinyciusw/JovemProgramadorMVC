using JovemProgramadorMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JovemProgramadorMVC.Data.Repositorio.Interface
{
    public interface IAlunoRepositorio
    {
        void InserirAluno(AlunoModel alunos);
        AlunoModel Atualizar(AlunoModel alunos);
        AlunoModel Excluir(AlunoModel alunos);
        List<AlunoModel> BuscarAlunos();
        AlunoModel BuscarId(int id);
    }
}