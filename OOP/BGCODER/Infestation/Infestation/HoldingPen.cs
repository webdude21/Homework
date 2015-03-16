﻿namespace Infestation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class HoldingPen
    {
        private List<Unit> containedUnits = new List<Unit>();

        public void ParseCommand(string command)
        {
            string[] commandWordSeparators = { " " };

            var commandWords = command.Split(commandWordSeparators, StringSplitOptions.RemoveEmptyEntries);

            this.DispatchCommand(commandWords);
        }

        protected virtual void DispatchCommand(string[] commandWords)
        {
            switch (commandWords[0])
            {
                case "insert":
                    this.ExecuteInsertUnitCommand(commandWords);
                    break;
                case "proceed":
                    this.ExecuteProceedSingleIterationCommand();
                    break;
                case "supplement":
                    this.ExecuteAddSupplementCommand(commandWords);
                    break;
                case "status":
                    this.ExecutePrintStatusCommand();
                    break;
            }
        }

        private void ExecutePrintStatusCommand()
        {
            foreach (var unit in this.containedUnits)
            {
                Console.WriteLine(unit);
            }
        }

        protected virtual void ExecuteAddSupplementCommand(string[] commandWords)
        {
            throw new NotImplementedException();
        }

        protected virtual void ExecuteProceedSingleIterationCommand()
        {
            var containedUnitsInfo = this.containedUnits.Select(unit => unit.Info);

            var requestedInteractions = from unit in this.containedUnits
                                        select unit.DecideInteraction(containedUnitsInfo);

            requestedInteractions =
                requestedInteractions.Where(interaction => interaction != Interaction.PassiveInteraction);

            foreach (var interaction in requestedInteractions)
            {
                this.ProcessSingleInteraction(interaction);
            }

            this.containedUnits.RemoveAll(unit => unit.IsDestroyed);
        }

        protected virtual void ProcessSingleInteraction(Interaction interaction)
        {
            switch (interaction.InteractionType)
            {
                case InteractionType.Attack:
                    var targetUnit = this.GetUnit(interaction.TargetUnit);

                    targetUnit.DecreaseBaseHealth(interaction.SourceUnit.Power);
                    break;
            }
        }

        protected Unit GetUnit(string unitId)
        {
            return this.containedUnits.FirstOrDefault(unit => unit.Id == unitId);
        }

        protected Unit GetUnit(UnitInfo unitInfo)
        {
            return this.GetUnit(unitInfo.Id);
            //return this.containedUnits.FirstOrDefault((unit) => unit.Id == unitInfo.Id);
        }

        protected virtual void ExecuteInsertUnitCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "Dog":
                    var dog = new Dog(commandWords[2]);
                    this.InsertUnit(dog);
                    break;
                case "Human":
                    var human = new Human(commandWords[2]);
                    this.InsertUnit(human);
                    break;
            }
        }

        protected void InsertUnit(Unit unit)
        {
            this.containedUnits.Add(unit);
        }
    }
}