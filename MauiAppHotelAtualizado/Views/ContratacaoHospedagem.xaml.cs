using MauiAppHotelAtualizado.Models;

namespace MauiAppHotelAtualizado.Views;

public partial class ContratacaoHospedagem : ContentPage
{
	public ContratacaoHospedagem()
	{
		InitializeComponent();

		pck_quarto.ItemsSource = App.lista_quartos;

        dtpck_checkin.MinimumDate = DateTime.Now;
        dtpck_checkin.MaximumDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, DateTime.Now.Day);

        dtpck_checkout.MinimumDate = dtpck_checkin.Date?.AddDays(1);
        dtpck_checkout.MaximumDate = dtpck_checkin.Date?.AddMonths(2);
    }

    private void dtpck_checkin_DateSelected(object sender, DateChangedEventArgs e)
    {              
        dtpck_checkout.MinimumDate = e.NewDate?.AddDays(1);
        dtpck_checkout.MaximumDate = e.NewDate?.AddMonths(2);
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            Hospedagem h = new()
            {
                QntAdultos = Convert.ToInt32(stp_adultos.Value),
                QntCriancas = Convert.ToInt32(stp_criancas.Value),
                QuartoSelecionado = (Quarto) pck_quarto.SelectedItem,
                DataCheckIn = Convert.ToDateTime(dtpck_checkin.Date),
                DataCheckOut = Convert.ToDateTime(dtpck_checkout.Date)
            };

            Navigation.PushAsync(new HospedagemContratada()
            {
                BindingContext = h
            });

        }
        catch (Exception ex)
        {
            DisplayAlertAsync("Ops", ex.Message, "OK");
        }

    }
}