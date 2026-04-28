namespace VeiculosHerdeiros
{
    abstract class Veiculo
    {
        protected float capacidadeTanque;
        protected int cavalariaMotor;
        protected float velocidadeMaxima;
        protected float velocidadeAtual;

        public float CapacidadeTanque => capacidadeTanque;
        public int CavalariaMotor => cavalariaMotor;
        public float VelocidadeMaxima => velocidadeMaxima;
        public float VelocidadeAtual { 
            get 
            {
                return velocidadeAtual;
            } 
            protected set
            {
                velocidadeAtual = value;
                if(velocidadeAtual > VelocidadeMaxima)
                {
                    velocidadeAtual = VelocidadeMaxima;
                }else if(velocidadeAtual < 0)
                {
                    velocidadeAtual = 0;
                }
            }
        }

        public abstract void Acelerar();
        public abstract void Frear();
    }

    class CarroPasseio : Veiculo
    {
        private int quantidadeDePortas;
        public int QuantidadeDePortas => quantidadeDePortas;

        public override void Acelerar()
        {
            VelocidadeAtual += 10;
        }
        public override void Frear()
        {
            VelocidadeAtual -= 8;
        }
    }

    class CarroUtilitario : Veiculo
    {
        private float capacidadeDeCarga;
        public float CapacidadeDeCarg => capacidadeDeCarga;

        public override void Acelerar()
        {
            VelocidadeAtual += 5;
        }

        public override void Frear()
        {
            VelocidadeAtual -= 3;
        }
    }
}
