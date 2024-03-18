using System;
using System.IO;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace asciiRecognizer {
    public struct Network {
        Vector<double>[] neurons; // Contains the values of each neuron in the network, each layer has its own vector
        Matrix<double>[] edges; // Contains all of the weights in the network, each layer has its own matrix
        Vector<double>[] bias; // Contains the bias of each neuron in the network, each layer has its own vector
        int numLayers; // The number of layers

        public Network(int l, int[] npl, int seed){
            edges = new Matrix<double>[l - 1];
            neurons = new Vector<double>[l];
            bias = new Vector<double>[l - 1];
            numLayers = l;

            setupLayers(npl, seed);
        }

        void setupLayers(int[] npl, int seed){
            neurons[0] = DenseVector.OfArray(new double[npl[0]]);

            for (int i = 1; i < numLayers; i++){
                neurons[i] = DenseVector.OfArray(new double[npl[i]]);
                edges[i] = Matrix.Build.Random(npl[i], npl[i - 1], seed);
                bias[i] = Vector.Build.Random(npl[i], seed);
            }
        }
    }

    internal class Perceptron {
        public static void Main(){
            Vector<double> a = DenseVector.OfArray([3,2,1]);
            Vector<double> b = DenseVector.OfArray([2,2,5]);

            Console.WriteLine(a * b);
        }

        void driver(string trainDataDir, int numLayers, int[] neuronsPerLayer, int seed){
            Network net = new Network(numLayers, neuronsPerLayer, seed);

            // Neurons are now randomized and are ready to start shooting out random shit
            // Need to create function in neuron struct to calculate value using sigmoid
            // Need to read in training data
            // Need to do back propagation
            // Need to comment below functions
        }
    }
}