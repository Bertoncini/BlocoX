﻿/********************************************************************************/
/* Projeto: Biblioteca BlocoX                                                   */
/* Biblioteca C# para emissão do BlocoX (ReduçãoZ e Estoque)                    */
/*https://www.confaz.fazenda.gov.br/legislacao/despacho/2017/dp045_17           */
/*                                                                              */
/* Direitos Autorais Reservados (c) 2019 Alexsandro Bertoncini                  */
/*                                       alex.bertoncini@terra.com.br           */
/*                                                                              */
/*  Você pode obter a última versão desse arquivo no GitHub                     */
/* localizado em https://github.com/Bertoncini/BlocoX                           */
/*                                                                              */
/*                                                                              */
/*  Esta biblioteca é software livre; você pode redistribuí-la e/ou modificá-la */
/* sob os termos da Licença Pública Geral Menor do GNU conforme publicada pela  */
/* Free Software Foundation; tanto a versão 2.1 da Licença, ou (a seu critério) */
/* qualquer versão posterior.                                                   */
/*                                                                              */
/*  Esta biblioteca é distribuída na expectativa de que seja útil, porém, SEM   */
/* NENHUMA GARANTIA; nem mesmo a garantia implícita de COMERCIABILIDADE OU      */
/* ADEQUAÇÃO A UMA FINALIDADE ESPECÍFICA. Consulte a Licença Pública Geral Menor*/
/* do GNU para mais detalhes. (Arquivo LICENÇA.TXT ou LICENSE.TXT)              */
/*                                                                              */
/*  Você deve ter recebido uma cópia da Licença Pública Geral Menor do GNU junto*/
/* com esta biblioteca; se não, escreva para a Free Software Foundation, Inc.,  */
/* no endereço 59 Temple Street, Suite 330, Boston, MA 02111-1307 USA.          */
/* Você também pode obter uma copia da licença em:                              */
/* http://www.opensource.org/licenses/lgpl-license.php                          */
/*                                                                              */
/********************************************************************************/
namespace BlocoX.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Security.Cryptography.X509Certificates;

    public class Config
    {
        public bool Ambiente { get; private set; }
        public string DiretorioSalvarArquivos { get; private set; }
        public string CaminhoCertificado { get; private set; }
        public string SenhaCertificado { get; private set; }

        public X509Certificate2 Certificado => new X509Certificate2(CaminhoCertificado, SenhaCertificado);


        public Config(bool ambiente, string diretorioSalvarArquivos, string caminhoCertificado, string senhaCertificado)
        {
            if (string.IsNullOrWhiteSpace(caminhoCertificado))
                throw new ArgumentNullException("Não foi informado o local do Certificado");

            if (string.IsNullOrWhiteSpace(senhaCertificado))
                throw new ArgumentNullException("Não foi informado a senha do Certificado");

            DiretorioSalvarArquivos = diretorioSalvarArquivos;
            CaminhoCertificado = caminhoCertificado;
            SenhaCertificado = senhaCertificado;
        }
    }
}
