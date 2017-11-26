<?php

namespace CalculatorBundle\Controller;

use CalculatorBundle\Entity\Calculator;
use CalculatorBundle\Form\CalculatorType;
use Sensio\Bundle\FrameworkExtraBundle\Configuration\Route;
use Symfony\Bundle\FrameworkBundle\Controller\Controller;
use Symfony\Component\HttpFoundation\Request;

class CalculatorController extends Controller
{
    /**
     * @param Request $request
     *
     * @Route("/", name="index")
     *
     * @return \Symfony\Component\HttpFoundation\Response
     *
     */
    public function index(Request $request)
    {
        $calculator = new Calculator();

        $form = $this->createForm(CalculatorType::class, $calculator);

        $form->handleRequest($request);

        if ($form->isSubmitted() && $form->isValid()) {

            $leftOperand = $calculator->getLeftOperand();
            $rightOperand = $calculator->getRightOperand();
            $operator = $calculator->getOperator();

            $result = 0;
            switch ($operator) {
                case '+':
                    $result = $leftOperand + $rightOperand;
                    break;
                case '-':
                    $result = $leftOperand - $rightOperand;
                    break;
                case '*':
                    $result = $leftOperand * $rightOperand;
                    break;
                case '/':
                    if ($rightOperand == 0)
                        $result = "Error";
                    else
                        $result = $leftOperand / $rightOperand;
                    break;
                case '^':
                    $result = $leftOperand ** $rightOperand;
                    break;
                case '%':
                    if ($rightOperand == 0)
                        $result = "Error";
                    else
                        $result = $leftOperand % $rightOperand;
                    break;
            }
            return $this->render('calculator/index.html.twig',
                ['result' => $result, 'calculator' => $calculator, 'form' => $form->createView()]);
        }


        return $this->render('calculator/index.html.twig', ['form' => $form->createView()]);
    }
}
