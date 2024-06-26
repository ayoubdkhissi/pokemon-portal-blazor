﻿using BlazorBootstrap;
using Microsoft.AspNetCore.Components;
using pokemon_portal_blazor.DTOs;

namespace pokemon_portal_blazor.Components.ChartCards;

public partial class CatchCountByPower : ComponentBase
{
    private PieChart pieChart = default!;
    private PieChartOptions pieChartOptions = default!;
    private ChartData chartData = default!;

    [Parameter] public List<PokemonsByPowerData> Data { get; set; }

    protected override void OnInitialized()
    {
        chartData = new ChartData 
        { 
            Labels = Data.Select(p => p.Power.Name).ToList(), 
            Datasets = GetDataSets() 
        };

        pieChartOptions = new();
        pieChartOptions.Responsive = true;
        pieChartOptions.Plugins.Title!.Text = "Pokémons Catched by Power";
        pieChartOptions.Plugins.Title.Display = true;
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await pieChart.InitializeAsync(chartData, pieChartOptions);
        }
        await base.OnAfterRenderAsync(firstRender);
    }

    private List<IChartDataset> GetDataSets()
    {
        var datasets = new List<IChartDataset>
        {
            new PieChartDataset
            {
                Label = "Catch Count",
                Data = Data.Select(d => (double)d.CatchCount).ToList(),
                BackgroundColor = Data.Select(d => d.Power.Color).ToList()
            }
        };

        return datasets;
    }

}

