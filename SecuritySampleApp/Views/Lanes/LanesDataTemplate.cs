using Xamarin.Forms;
using Xamarin.CommunityToolkit.Markup;
using static Xamarin.CommunityToolkit.Markup.GridRowsColumns;

namespace SecuritySampleApp
{
    class LanesDataTemplate : DataTemplate
    {
        public LanesDataTemplate() : base(CreateLanes)
        {
        }

        static Grid CreateLanes() => new Grid
        {
            RowDefinitions = Rows.Define(
                    (Row.Text, Star),
                    (Row.Switch, Star)),

            ColumnDefinitions = Columns.Define(
                    (Column.Image, Star),
                    (Column.Open, Star),
                    (Column.Maintenance, Star)),

            Children =
            {
                new LaneImage().RowSpan(All<Row>()).Column(Column.Image),

                new TextLabel("Is Open").Row(Row.Text).Column(Column.Open),
                new Switch().Row(Row.Switch).Column(Column.Open)
                    .Bind(Switch.IsToggledProperty, nameof(LaneModel.IsOpen)),

                new TextLabel("Needs Maintanence").Row(Row.Text).Column(Column.Maintenance),
                new Switch().Row(Row.Switch).Column(Column.Maintenance)
                    .Bind(Switch.IsToggledProperty, nameof(LaneModel.NeedsMaintenance)),
            }
        };

        enum Column { Image, Open, Maintenance }
        enum Row { Text, Switch }

        class LaneImage : Image
        {
            public LaneImage()
            {
                HeightRequest = 150;
                BackgroundColor = Color.White;
                Source = "Road";
            }
        }

        class TextLabel : Label
        {
            public TextLabel(in string text)
            {
                Text = text;
                FontAttributes = FontAttributes.Bold;
            }
        }
    }
}
