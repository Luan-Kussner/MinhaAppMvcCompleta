using System.Collections.Generic;
using DevLuan.Business.Notificacoes;

namespace DevLuan.Business.Intefaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}