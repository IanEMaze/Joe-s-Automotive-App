using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Joe_s_Automotive
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ClearOilLube() {
            //Clears the oil and lube group
            oilChangeBox.Checked = false;
            lubeJobBox.Checked = false;
        }

        private void ClearFlushes()
        {
            //Clears the flushed group
            radiatorFlushBox.Checked = false;
            transFlushBox.Checked = false;
        }

        private void ClearMisc()
        {
            //clears the misc group
            inspectionBox.Checked = false;
            MufflerBox.Checked = false;
            rotationBox.Checked = false;
        }

        private void ClearOther()
        {
            //Clears the other repairs group
            otherRepairBox.Checked = false;
            partsInput.Text = "";
            laborInput.Text = "";
        }

        private void ClearFees()
        {
            //Clears the summary group
            serviceAndLabor.Text = "";
            parts.Text = "";
            taxParts.Text = "";
            totalFee.Text = "";
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            //Button click runs each clear method 
            ClearOilLube();
            ClearFlushes();
            ClearMisc();
            ClearOther();
            ClearFees();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            //Closes form window
            this.Close();
        }

        private double OilLubeCharges() {
            //returns the total charges for an oil change and / or a lube job, if any.
            double total = 0;

            if (oilChangeBox.Checked == true) {
                total = total + 26.00;
            }

            if (lubeJobBox.Checked == true) {
                total = total + 18.00;
            }

            return total;
        }

        private double FlushCharges() {
            //returns the total charges for a radiator flush and / or a transmission flush, if any.
            double total = 0;

            if (radiatorFlushBox.Checked == true) {
                total += 30.00;
            }

            if (transFlushBox.Checked == true)
            {
                total += 80.00;
            }

            return total;
        }

        private double MiscCharges() {
            //returns the total charges for an inspection, muffler replacement, and / or a tire rotation, if any.
            double total = 0;

            if (inspectionBox.Checked == true) {
                total += 15.00;
            }

            if (MufflerBox.Checked == true) {
                total += 100.00;
            }

            if (rotationBox.Checked == true) {
                total += 20.00;
            }
            
            return total;
        }

        private double OtherCharges() {
            //returns the total charges for other services (parts and labor), if any.
            double total = 0;
            double laborAmount = 20.00;
            double NewLaborNum = 0.00;
            if (otherRepairBox.Checked == true) {
                parts.Text = "" + partsInput.Text;
                total += double.Parse(partsInput.Text);

                NewLaborNum = laborAmount * double.Parse(laborInput.Text);
                total += NewLaborNum;
            }
            return total;
        }

        private double TaxCharges() {
            double total = 0.00;
            double PartTax = 0.06;
            double PartAfterTax = 0.00;
            //returns the amount of sales tax, if any.Sales tax is 6 % and is charged only on parts.  
            //If the customer purchases services only, no sales tax is charged.
            PartAfterTax = double.Parse(partsInput.Text) * PartTax;
            taxParts.Text = "" + PartAfterTax;
            total += PartAfterTax;
            return total;
        }

        private void TotalCharges(double total) {
            //TotalCharges - returns the total charges.
            double num = 0;

            num += double.Parse(serviceAndLabor.Text);
            num += double.Parse(parts.Text);
            num += double.Parse(taxParts.Text);

            
            totalFee.Text = "" + num;
        }

        private void DisplayAmounts() {
            double total, partsNum, tax, serviceLabor = 0.00;
            //Grabbing each value
            total = double.Parse(totalFee.Text);
            partsNum = double.Parse(parts.Text);
            tax = double.Parse(taxParts.Text);
            serviceLabor = double.Parse(serviceAndLabor.Text);

            //Displaying data as currency
            totalFee.Text = "" + total.ToString("c");
            parts.Text = "" + partsNum.ToString("c");
            taxParts.Text = "" + tax.ToString("c");
            serviceAndLabor.Text = "" + serviceLabor.ToString("c");
        }

        private void mathButton_Click(object sender, EventArgs e)
        {
            double total = 0;
            total += OilLubeCharges();
            total += FlushCharges();
            total += MiscCharges();
            total += OtherCharges();
            total += TaxCharges();
            serviceAndLabor.Text = "" + total;
            TotalCharges(total);
            DisplayAmounts();
        }

        
    }
}
