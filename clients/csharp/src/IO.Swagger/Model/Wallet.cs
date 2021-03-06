/* 
 * BitMEX API
 *
 * ## REST API for the BitMEX Trading Platform  [View Changelog](/app/apiChangelog)    #### Getting Started   ##### Fetching Data  All REST endpoints are documented below. You can try out any query right from this interface.  Most table queries accept `count`, `start`, and `reverse` params. Set `reverse=true` to get rows newest-first.  Additional documentation regarding filters, timestamps, and authentication is available in [the main API documentation](https://www.bitmex.com/app/restAPI).  *All* table data is available via the [Websocket](/app/wsAPI). We highly recommend using the socket if you want to have the quickest possible data without being subject to ratelimits.  ##### Return Types  By default, all data is returned as JSON. Send `?_format=csv` to get CSV data or `?_format=xml` to get XML data.  ##### Trade Data Queries  *This is only a small subset of what is available, to get you started.*  Fill in the parameters and click the `Try it out!` button to try any of these queries.  * [Pricing Data](#!/Quote/Quote_get)  * [Trade Data](#!/Trade/Trade_get)  * [OrderBook Data](#!/OrderBook/OrderBook_getL2)  * [Settlement Data](#!/Settlement/Settlement_get)  * [Exchange Statistics](#!/Stats/Stats_history)  Every function of the BitMEX.com platform is exposed here and documented. Many more functions are available.  ##### Swagger Specification  [⇩ Download Swagger JSON](swagger.json)    ## All API Endpoints  Click to expand a section. 
 *
 * OpenAPI spec version: 1.2.0
 * Contact: support@bitmex.com
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using SwaggerDateConverter = IO.Swagger.Client.SwaggerDateConverter;

namespace IO.Swagger.Model
{
    /// <summary>
    /// Wallet
    /// </summary>
    [DataContract]
    public partial class Wallet :  IEquatable<Wallet>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Wallet" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected Wallet() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Wallet" /> class.
        /// </summary>
        /// <param name="Account">Account (required).</param>
        /// <param name="Currency">Currency (required).</param>
        /// <param name="PrevDeposited">PrevDeposited.</param>
        /// <param name="PrevWithdrawn">PrevWithdrawn.</param>
        /// <param name="PrevTransferIn">PrevTransferIn.</param>
        /// <param name="PrevTransferOut">PrevTransferOut.</param>
        /// <param name="PrevAmount">PrevAmount.</param>
        /// <param name="PrevTimestamp">PrevTimestamp.</param>
        /// <param name="DeltaDeposited">DeltaDeposited.</param>
        /// <param name="DeltaWithdrawn">DeltaWithdrawn.</param>
        /// <param name="DeltaTransferIn">DeltaTransferIn.</param>
        /// <param name="DeltaTransferOut">DeltaTransferOut.</param>
        /// <param name="DeltaAmount">DeltaAmount.</param>
        /// <param name="Deposited">Deposited.</param>
        /// <param name="Withdrawn">Withdrawn.</param>
        /// <param name="TransferIn">TransferIn.</param>
        /// <param name="TransferOut">TransferOut.</param>
        /// <param name="Amount">Amount.</param>
        /// <param name="PendingCredit">PendingCredit.</param>
        /// <param name="PendingDebit">PendingDebit.</param>
        /// <param name="ConfirmedDebit">ConfirmedDebit.</param>
        /// <param name="Timestamp">Timestamp.</param>
        /// <param name="Addr">Addr.</param>
        /// <param name="Script">Script.</param>
        /// <param name="WithdrawalLock">WithdrawalLock.</param>
        public Wallet(decimal? Account = default(decimal?), string Currency = default(string), decimal? PrevDeposited = default(decimal?), decimal? PrevWithdrawn = default(decimal?), decimal? PrevTransferIn = default(decimal?), decimal? PrevTransferOut = default(decimal?), decimal? PrevAmount = default(decimal?), DateTime? PrevTimestamp = default(DateTime?), decimal? DeltaDeposited = default(decimal?), decimal? DeltaWithdrawn = default(decimal?), decimal? DeltaTransferIn = default(decimal?), decimal? DeltaTransferOut = default(decimal?), decimal? DeltaAmount = default(decimal?), decimal? Deposited = default(decimal?), decimal? Withdrawn = default(decimal?), decimal? TransferIn = default(decimal?), decimal? TransferOut = default(decimal?), decimal? Amount = default(decimal?), decimal? PendingCredit = default(decimal?), decimal? PendingDebit = default(decimal?), decimal? ConfirmedDebit = default(decimal?), DateTime? Timestamp = default(DateTime?), string Addr = default(string), string Script = default(string), List<string> WithdrawalLock = default(List<string>))
        {
            // to ensure "Account" is required (not null)
            if (Account == null)
            {
                throw new InvalidDataException("Account is a required property for Wallet and cannot be null");
            }
            else
            {
                this.Account = Account;
            }
            // to ensure "Currency" is required (not null)
            if (Currency == null)
            {
                throw new InvalidDataException("Currency is a required property for Wallet and cannot be null");
            }
            else
            {
                this.Currency = Currency;
            }
            this.PrevDeposited = PrevDeposited;
            this.PrevWithdrawn = PrevWithdrawn;
            this.PrevTransferIn = PrevTransferIn;
            this.PrevTransferOut = PrevTransferOut;
            this.PrevAmount = PrevAmount;
            this.PrevTimestamp = PrevTimestamp;
            this.DeltaDeposited = DeltaDeposited;
            this.DeltaWithdrawn = DeltaWithdrawn;
            this.DeltaTransferIn = DeltaTransferIn;
            this.DeltaTransferOut = DeltaTransferOut;
            this.DeltaAmount = DeltaAmount;
            this.Deposited = Deposited;
            this.Withdrawn = Withdrawn;
            this.TransferIn = TransferIn;
            this.TransferOut = TransferOut;
            this.Amount = Amount;
            this.PendingCredit = PendingCredit;
            this.PendingDebit = PendingDebit;
            this.ConfirmedDebit = ConfirmedDebit;
            this.Timestamp = Timestamp;
            this.Addr = Addr;
            this.Script = Script;
            this.WithdrawalLock = WithdrawalLock;
        }
        
        /// <summary>
        /// Gets or Sets Account
        /// </summary>
        [DataMember(Name="account", EmitDefaultValue=false)]
        public decimal? Account { get; set; }

        /// <summary>
        /// Gets or Sets Currency
        /// </summary>
        [DataMember(Name="currency", EmitDefaultValue=false)]
        public string Currency { get; set; }

        /// <summary>
        /// Gets or Sets PrevDeposited
        /// </summary>
        [DataMember(Name="prevDeposited", EmitDefaultValue=false)]
        public decimal? PrevDeposited { get; set; }

        /// <summary>
        /// Gets or Sets PrevWithdrawn
        /// </summary>
        [DataMember(Name="prevWithdrawn", EmitDefaultValue=false)]
        public decimal? PrevWithdrawn { get; set; }

        /// <summary>
        /// Gets or Sets PrevTransferIn
        /// </summary>
        [DataMember(Name="prevTransferIn", EmitDefaultValue=false)]
        public decimal? PrevTransferIn { get; set; }

        /// <summary>
        /// Gets or Sets PrevTransferOut
        /// </summary>
        [DataMember(Name="prevTransferOut", EmitDefaultValue=false)]
        public decimal? PrevTransferOut { get; set; }

        /// <summary>
        /// Gets or Sets PrevAmount
        /// </summary>
        [DataMember(Name="prevAmount", EmitDefaultValue=false)]
        public decimal? PrevAmount { get; set; }

        /// <summary>
        /// Gets or Sets PrevTimestamp
        /// </summary>
        [DataMember(Name="prevTimestamp", EmitDefaultValue=false)]
        public DateTime? PrevTimestamp { get; set; }

        /// <summary>
        /// Gets or Sets DeltaDeposited
        /// </summary>
        [DataMember(Name="deltaDeposited", EmitDefaultValue=false)]
        public decimal? DeltaDeposited { get; set; }

        /// <summary>
        /// Gets or Sets DeltaWithdrawn
        /// </summary>
        [DataMember(Name="deltaWithdrawn", EmitDefaultValue=false)]
        public decimal? DeltaWithdrawn { get; set; }

        /// <summary>
        /// Gets or Sets DeltaTransferIn
        /// </summary>
        [DataMember(Name="deltaTransferIn", EmitDefaultValue=false)]
        public decimal? DeltaTransferIn { get; set; }

        /// <summary>
        /// Gets or Sets DeltaTransferOut
        /// </summary>
        [DataMember(Name="deltaTransferOut", EmitDefaultValue=false)]
        public decimal? DeltaTransferOut { get; set; }

        /// <summary>
        /// Gets or Sets DeltaAmount
        /// </summary>
        [DataMember(Name="deltaAmount", EmitDefaultValue=false)]
        public decimal? DeltaAmount { get; set; }

        /// <summary>
        /// Gets or Sets Deposited
        /// </summary>
        [DataMember(Name="deposited", EmitDefaultValue=false)]
        public decimal? Deposited { get; set; }

        /// <summary>
        /// Gets or Sets Withdrawn
        /// </summary>
        [DataMember(Name="withdrawn", EmitDefaultValue=false)]
        public decimal? Withdrawn { get; set; }

        /// <summary>
        /// Gets or Sets TransferIn
        /// </summary>
        [DataMember(Name="transferIn", EmitDefaultValue=false)]
        public decimal? TransferIn { get; set; }

        /// <summary>
        /// Gets or Sets TransferOut
        /// </summary>
        [DataMember(Name="transferOut", EmitDefaultValue=false)]
        public decimal? TransferOut { get; set; }

        /// <summary>
        /// Gets or Sets Amount
        /// </summary>
        [DataMember(Name="amount", EmitDefaultValue=false)]
        public decimal? Amount { get; set; }

        /// <summary>
        /// Gets or Sets PendingCredit
        /// </summary>
        [DataMember(Name="pendingCredit", EmitDefaultValue=false)]
        public decimal? PendingCredit { get; set; }

        /// <summary>
        /// Gets or Sets PendingDebit
        /// </summary>
        [DataMember(Name="pendingDebit", EmitDefaultValue=false)]
        public decimal? PendingDebit { get; set; }

        /// <summary>
        /// Gets or Sets ConfirmedDebit
        /// </summary>
        [DataMember(Name="confirmedDebit", EmitDefaultValue=false)]
        public decimal? ConfirmedDebit { get; set; }

        /// <summary>
        /// Gets or Sets Timestamp
        /// </summary>
        [DataMember(Name="timestamp", EmitDefaultValue=false)]
        public DateTime? Timestamp { get; set; }

        /// <summary>
        /// Gets or Sets Addr
        /// </summary>
        [DataMember(Name="addr", EmitDefaultValue=false)]
        public string Addr { get; set; }

        /// <summary>
        /// Gets or Sets Script
        /// </summary>
        [DataMember(Name="script", EmitDefaultValue=false)]
        public string Script { get; set; }

        /// <summary>
        /// Gets or Sets WithdrawalLock
        /// </summary>
        [DataMember(Name="withdrawalLock", EmitDefaultValue=false)]
        public List<string> WithdrawalLock { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Wallet {\n");
            sb.Append("  Account: ").Append(Account).Append("\n");
            sb.Append("  Currency: ").Append(Currency).Append("\n");
            sb.Append("  PrevDeposited: ").Append(PrevDeposited).Append("\n");
            sb.Append("  PrevWithdrawn: ").Append(PrevWithdrawn).Append("\n");
            sb.Append("  PrevTransferIn: ").Append(PrevTransferIn).Append("\n");
            sb.Append("  PrevTransferOut: ").Append(PrevTransferOut).Append("\n");
            sb.Append("  PrevAmount: ").Append(PrevAmount).Append("\n");
            sb.Append("  PrevTimestamp: ").Append(PrevTimestamp).Append("\n");
            sb.Append("  DeltaDeposited: ").Append(DeltaDeposited).Append("\n");
            sb.Append("  DeltaWithdrawn: ").Append(DeltaWithdrawn).Append("\n");
            sb.Append("  DeltaTransferIn: ").Append(DeltaTransferIn).Append("\n");
            sb.Append("  DeltaTransferOut: ").Append(DeltaTransferOut).Append("\n");
            sb.Append("  DeltaAmount: ").Append(DeltaAmount).Append("\n");
            sb.Append("  Deposited: ").Append(Deposited).Append("\n");
            sb.Append("  Withdrawn: ").Append(Withdrawn).Append("\n");
            sb.Append("  TransferIn: ").Append(TransferIn).Append("\n");
            sb.Append("  TransferOut: ").Append(TransferOut).Append("\n");
            sb.Append("  Amount: ").Append(Amount).Append("\n");
            sb.Append("  PendingCredit: ").Append(PendingCredit).Append("\n");
            sb.Append("  PendingDebit: ").Append(PendingDebit).Append("\n");
            sb.Append("  ConfirmedDebit: ").Append(ConfirmedDebit).Append("\n");
            sb.Append("  Timestamp: ").Append(Timestamp).Append("\n");
            sb.Append("  Addr: ").Append(Addr).Append("\n");
            sb.Append("  Script: ").Append(Script).Append("\n");
            sb.Append("  WithdrawalLock: ").Append(WithdrawalLock).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as Wallet);
        }

        /// <summary>
        /// Returns true if Wallet instances are equal
        /// </summary>
        /// <param name="input">Instance of Wallet to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Wallet input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Account == input.Account ||
                    (this.Account != null &&
                    this.Account.Equals(input.Account))
                ) && 
                (
                    this.Currency == input.Currency ||
                    (this.Currency != null &&
                    this.Currency.Equals(input.Currency))
                ) && 
                (
                    this.PrevDeposited == input.PrevDeposited ||
                    (this.PrevDeposited != null &&
                    this.PrevDeposited.Equals(input.PrevDeposited))
                ) && 
                (
                    this.PrevWithdrawn == input.PrevWithdrawn ||
                    (this.PrevWithdrawn != null &&
                    this.PrevWithdrawn.Equals(input.PrevWithdrawn))
                ) && 
                (
                    this.PrevTransferIn == input.PrevTransferIn ||
                    (this.PrevTransferIn != null &&
                    this.PrevTransferIn.Equals(input.PrevTransferIn))
                ) && 
                (
                    this.PrevTransferOut == input.PrevTransferOut ||
                    (this.PrevTransferOut != null &&
                    this.PrevTransferOut.Equals(input.PrevTransferOut))
                ) && 
                (
                    this.PrevAmount == input.PrevAmount ||
                    (this.PrevAmount != null &&
                    this.PrevAmount.Equals(input.PrevAmount))
                ) && 
                (
                    this.PrevTimestamp == input.PrevTimestamp ||
                    (this.PrevTimestamp != null &&
                    this.PrevTimestamp.Equals(input.PrevTimestamp))
                ) && 
                (
                    this.DeltaDeposited == input.DeltaDeposited ||
                    (this.DeltaDeposited != null &&
                    this.DeltaDeposited.Equals(input.DeltaDeposited))
                ) && 
                (
                    this.DeltaWithdrawn == input.DeltaWithdrawn ||
                    (this.DeltaWithdrawn != null &&
                    this.DeltaWithdrawn.Equals(input.DeltaWithdrawn))
                ) && 
                (
                    this.DeltaTransferIn == input.DeltaTransferIn ||
                    (this.DeltaTransferIn != null &&
                    this.DeltaTransferIn.Equals(input.DeltaTransferIn))
                ) && 
                (
                    this.DeltaTransferOut == input.DeltaTransferOut ||
                    (this.DeltaTransferOut != null &&
                    this.DeltaTransferOut.Equals(input.DeltaTransferOut))
                ) && 
                (
                    this.DeltaAmount == input.DeltaAmount ||
                    (this.DeltaAmount != null &&
                    this.DeltaAmount.Equals(input.DeltaAmount))
                ) && 
                (
                    this.Deposited == input.Deposited ||
                    (this.Deposited != null &&
                    this.Deposited.Equals(input.Deposited))
                ) && 
                (
                    this.Withdrawn == input.Withdrawn ||
                    (this.Withdrawn != null &&
                    this.Withdrawn.Equals(input.Withdrawn))
                ) && 
                (
                    this.TransferIn == input.TransferIn ||
                    (this.TransferIn != null &&
                    this.TransferIn.Equals(input.TransferIn))
                ) && 
                (
                    this.TransferOut == input.TransferOut ||
                    (this.TransferOut != null &&
                    this.TransferOut.Equals(input.TransferOut))
                ) && 
                (
                    this.Amount == input.Amount ||
                    (this.Amount != null &&
                    this.Amount.Equals(input.Amount))
                ) && 
                (
                    this.PendingCredit == input.PendingCredit ||
                    (this.PendingCredit != null &&
                    this.PendingCredit.Equals(input.PendingCredit))
                ) && 
                (
                    this.PendingDebit == input.PendingDebit ||
                    (this.PendingDebit != null &&
                    this.PendingDebit.Equals(input.PendingDebit))
                ) && 
                (
                    this.ConfirmedDebit == input.ConfirmedDebit ||
                    (this.ConfirmedDebit != null &&
                    this.ConfirmedDebit.Equals(input.ConfirmedDebit))
                ) && 
                (
                    this.Timestamp == input.Timestamp ||
                    (this.Timestamp != null &&
                    this.Timestamp.Equals(input.Timestamp))
                ) && 
                (
                    this.Addr == input.Addr ||
                    (this.Addr != null &&
                    this.Addr.Equals(input.Addr))
                ) && 
                (
                    this.Script == input.Script ||
                    (this.Script != null &&
                    this.Script.Equals(input.Script))
                ) && 
                (
                    this.WithdrawalLock == input.WithdrawalLock ||
                    this.WithdrawalLock != null &&
                    this.WithdrawalLock.SequenceEqual(input.WithdrawalLock)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.Account != null)
                    hashCode = hashCode * 59 + this.Account.GetHashCode();
                if (this.Currency != null)
                    hashCode = hashCode * 59 + this.Currency.GetHashCode();
                if (this.PrevDeposited != null)
                    hashCode = hashCode * 59 + this.PrevDeposited.GetHashCode();
                if (this.PrevWithdrawn != null)
                    hashCode = hashCode * 59 + this.PrevWithdrawn.GetHashCode();
                if (this.PrevTransferIn != null)
                    hashCode = hashCode * 59 + this.PrevTransferIn.GetHashCode();
                if (this.PrevTransferOut != null)
                    hashCode = hashCode * 59 + this.PrevTransferOut.GetHashCode();
                if (this.PrevAmount != null)
                    hashCode = hashCode * 59 + this.PrevAmount.GetHashCode();
                if (this.PrevTimestamp != null)
                    hashCode = hashCode * 59 + this.PrevTimestamp.GetHashCode();
                if (this.DeltaDeposited != null)
                    hashCode = hashCode * 59 + this.DeltaDeposited.GetHashCode();
                if (this.DeltaWithdrawn != null)
                    hashCode = hashCode * 59 + this.DeltaWithdrawn.GetHashCode();
                if (this.DeltaTransferIn != null)
                    hashCode = hashCode * 59 + this.DeltaTransferIn.GetHashCode();
                if (this.DeltaTransferOut != null)
                    hashCode = hashCode * 59 + this.DeltaTransferOut.GetHashCode();
                if (this.DeltaAmount != null)
                    hashCode = hashCode * 59 + this.DeltaAmount.GetHashCode();
                if (this.Deposited != null)
                    hashCode = hashCode * 59 + this.Deposited.GetHashCode();
                if (this.Withdrawn != null)
                    hashCode = hashCode * 59 + this.Withdrawn.GetHashCode();
                if (this.TransferIn != null)
                    hashCode = hashCode * 59 + this.TransferIn.GetHashCode();
                if (this.TransferOut != null)
                    hashCode = hashCode * 59 + this.TransferOut.GetHashCode();
                if (this.Amount != null)
                    hashCode = hashCode * 59 + this.Amount.GetHashCode();
                if (this.PendingCredit != null)
                    hashCode = hashCode * 59 + this.PendingCredit.GetHashCode();
                if (this.PendingDebit != null)
                    hashCode = hashCode * 59 + this.PendingDebit.GetHashCode();
                if (this.ConfirmedDebit != null)
                    hashCode = hashCode * 59 + this.ConfirmedDebit.GetHashCode();
                if (this.Timestamp != null)
                    hashCode = hashCode * 59 + this.Timestamp.GetHashCode();
                if (this.Addr != null)
                    hashCode = hashCode * 59 + this.Addr.GetHashCode();
                if (this.Script != null)
                    hashCode = hashCode * 59 + this.Script.GetHashCode();
                if (this.WithdrawalLock != null)
                    hashCode = hashCode * 59 + this.WithdrawalLock.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}
