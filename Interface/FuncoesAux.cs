using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interface
{
    class FuncoesAux
    {
        Form1 myForm;
        public FuncoesAux(Form1 f)
        {
            myForm = f;
        }

        public void hideBtnsListBox(ListBox lb, Boolean b = false)
        {
            clearAllListBox();
            lb.Visible = true;
            if (b == true)
            {
                lb.Visible = false;
            }
        }

        public void Add(int button)
        {
            if (button == 1) myForm.lojas1.adicionarLoja();
            else if (button == 2) myForm.departamentos1.adicionarDepartamento();
            else if (button == 4) myForm.empresas1.adicionarEmpresas();
            else if (button == 5) myForm.eventos1.adicionarEvento();
            else if (button == 6) myForm.funcionarios1.adicionarFuncionario();
            else if (button == 7) myForm.resp_departamentos1.adicionarResponsavel();
        }

        public void Edit(int button)
        {
            if (button == 1) myForm.lojas1.editarLoja();
            else if (button == 2) myForm.departamentos1.editarDepartamento();
            else if (button == 3) myForm.prestadores1.editarPrestadores();
            else if (button == 4) myForm.empresas1.editarEmpresas();
            else if (button == 5) myForm.eventos1.editarEvento();
            else if (button == 6) myForm.funcionarios1.editarFuncionario();
            else if (button == 7) myForm.resp_departamentos1.editarResponsavel();
        }

        public void Search(int button)
        {
            if (button == 1) myForm.lojas1.Search();
            else if (button == 2) myForm.departamentos1.Search();
            else if (button == 3) myForm.prestadores1.Search();
            else if (button == 4) myForm.empresas1.Search();
            else if (button == 5) myForm.eventos1.Search();
            else if (button == 6) myForm.funcionarios1.Search();
            else if (button == 7) myForm.resp_departamentos1.Search();
        }

        public void CancelConfirm(int button)
        {
            if (button == 1) myForm.lojas1.cancelConfirmLoja();
            else if (button == 2) myForm.departamentos1.cancelConfirmDepartamento();
            else if (button == 5) myForm.eventos1.cancelConfirmEvento();
            else if (button == 6) myForm.funcionarios1.cancelConfirmFuncionario();
            else if (button == 7) myForm.resp_departamentos1.cancelConfirmResponsavel();
        }

        public void clearAllListBox()
        {
            myForm.listBox2.Visible = false;
            myForm.listBox3.Visible = false;
            myForm.listBox4.Visible = false;
            myForm.listBox5.Visible = false;
            myForm.listBox6.Visible = false;
            myForm.listBox7.Visible = false;
            myForm.listBox8.Visible = false;
        }

        public void ReadOnly()
        {
            myForm.lojas1.readOnlyLojas();
            myForm.departamentos1.readOnlyDepartamentos();
            myForm.prestadores1.readOnlyPrestadores();
            myForm.empresas1.readOnlyEmpresas();
            myForm.eventos1.readOnlyEventos();
            myForm.funcionarios1.readOnlyFuncionarios();
            myForm.resp_departamentos1.readOnlyResponsavel();
        }

        public void ShowButtons()
        {
            myForm.btnAdd.Visible = true;
            myForm.btnRemove.Visible = true;
            myForm.btnEdit.Visible = true;
            myForm.btnSearch.Visible = true;
            myForm.btnConfirm.Visible = false;
            myForm.btnCancel.Visible = false;
        }

        public void ShowAddBtn()
        {
            myForm.btnAdd.Visible = true;
            myForm.btnSearch.Visible = true;
            myForm.btnAddCentro.Visible = true;
            myForm.btnEditCentro.Visible = true;
            myForm.btnRemoveCentro.Visible = true;
            myForm.btnRemove.Visible = false;
            myForm.btnEdit.Visible = false;
            myForm.btnConfirm.Visible = false;
            myForm.btnCancel.Visible = false;
        }

        public void ClearFields()
        {
            myForm.lojas1.resetLojas();
            myForm.departamentos1.resetDepartamentos();
            myForm.prestadores1.resetPrestadores();
            myForm.empresas1.resetEmpresas();
            myForm.eventos1.resetEventos();
            myForm.funcionarios1.resetFuncionarios();
            myForm.resp_departamentos1.resetResponsavel();
        }

        public void LockButtons()
        {
            myForm.button1.Enabled = false;
            myForm.button2.Enabled = false;
            myForm.button3.Enabled = false;
            myForm.button4.Enabled = false;
            myForm.button5.Enabled = false;
            myForm.button6.Enabled = false;
            myForm.button7.Enabled = false;
        }

        public void UnlockButtons()
        {
            myForm.button1.Enabled = true;
            myForm.button2.Enabled = true;
            myForm.button3.Enabled = true;
            myForm.button4.Enabled = true;
            myForm.button5.Enabled = true;
            myForm.button6.Enabled = true;
            myForm.button7.Enabled = true;
        }

        public void DisableListBox()
        {
            myForm.listBox1.Enabled = false;
            myForm.listBox2.Enabled = false;
            myForm.listBox3.Enabled = false;
            myForm.listBox4.Enabled = false;
            myForm.listBox5.Enabled = false;
            myForm.listBox6.Enabled = false;
            myForm.listBox7.Enabled = false;
            myForm.listBox8.Enabled = false;
        }

        public void EnableListBox()
        {
            myForm.listBox1.Enabled = true;
            myForm.listBox2.Enabled = true;
            myForm.listBox3.Enabled = true;
            myForm.listBox4.Enabled = true;
            myForm.listBox5.Enabled = true;
            myForm.listBox6.Enabled = true;
            myForm.listBox7.Enabled = true;
            myForm.listBox8.Enabled = true;
        }

        public void HideButtons()
        {
            myForm.btnAdd.Visible = false;
            myForm.btnRemove.Visible = false;
            myForm.btnEdit.Visible = false;
            myForm.btnConfirm.Visible = false;
            myForm.btnCancel.Visible = false;
            myForm.btnSearch.Visible = false;
        }

        public void ShowConfCancButtons()
        {
            myForm.btnAdd.Visible = false;
            myForm.btnRemove.Visible = false;
            myForm.btnEdit.Visible = false;
            myForm.btnSearch.Visible = false;
            myForm.btnAddCentro.Visible = false;
            myForm.btnEditCentro.Visible = false;
            myForm.btnRemoveCentro.Visible = false;
            myForm.btnConfirm.Visible = true;
            myForm.btnCancel.Visible = true;
        }

        public void ReadOnlyCentro()
        {
            myForm.textCentroID.ReadOnly = true;
            myForm.textCentroNome.ReadOnly = true;
            myForm.textCentroLocalizacao.ReadOnly = true;
            myForm.textCentroNumeroLojas.ReadOnly = true;
            myForm.textCentroArea.ReadOnly = true;
        }

        public void EnableWrite()
        {
            myForm.lojas1.editableLojas();
            myForm.departamentos1.editableDepartamentos();
            myForm.prestadores1.editablePrestadores();
            myForm.empresas1.adicionarEmpresas();
            myForm.eventos1.editableEventos();
            myForm.funcionarios1.editableFuncionarios();
            myForm.resp_departamentos1.editableResponsavel();
        }

        public void EnableWriteCentro()
        {
            myForm.textCentroID.ReadOnly = false;
            myForm.textCentroNome.ReadOnly = false;
            myForm.textCentroLocalizacao.ReadOnly = false;
            myForm.textCentroNumeroLojas.ReadOnly = false;
            myForm.textCentroArea.ReadOnly = false;
        }

        public void UnselectListBox()
        {
            myForm.listBox2.SelectedIndex = -1;
            myForm.listBox3.SelectedIndex = -1;
            myForm.listBox4.SelectedIndex = -1;
            myForm.listBox5.SelectedIndex = -1;
            myForm.listBox6.SelectedIndex = -1;
            myForm.listBox7.SelectedIndex = -1;
            myForm.listBox8.SelectedIndex = -1;
        }
    }
}
