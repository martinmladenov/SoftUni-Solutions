<?php

namespace AppBundle\Controller;

use AppBundle\Entity\Report;
use AppBundle\Form\ReportType;
use Sensio\Bundle\FrameworkExtraBundle\Configuration\Route;
use Symfony\Bundle\FrameworkBundle\Controller\Controller;
use Symfony\Component\HttpFoundation\Request;

class ReportController extends Controller
{
    /**
     * @param Request $request
     * @Route("/", name="index")
     * @return \Symfony\Component\HttpFoundation\Response
     */
    public function index(Request $request)
    {
        $repo = $this->getDoctrine()->getRepository(Report::class);
        $reports = $repo->findAll();
        return $this->render("report/index.html.twig", ["reports" => $reports]);
    }

    /**
     * @Route("/details/{id}", name="details")
     *
     * @param $id
     * @param Request $request
     * @return \Symfony\Component\HttpFoundation\Response
     */
    public function details($id, Request $request)
    {
        $repo = $this->getDoctrine()->getRepository(Report::class);
        $report = $repo->find($id);
        if ($report == null) {
            return $this->redirect("/");
        }
        $form = $this->createForm(ReportType::class, $report);
        $form->handleRequest($request);
        return $this->render(
            "report/details.html.twig",
            ["report" => $report, "form" => $form->createView()]
        );

    }

    /**
     * @param Request $request
     * @Route("/create", name="create")
     * @return \Symfony\Component\HttpFoundation\Response
     */
    public function create(Request $request)
    {
        $report = new Report();
        $form = $this->createForm(ReportType::class, $report);
        $form->handleRequest($request);
        if ($form->isSubmitted() && $form->isValid()) {
            $em = $this->getDoctrine()->getManager();
            $em->persist($report);
            $em->flush();
            return $this->redirect("/");
        }
        return $this->render("report/create.html.twig",
            ["report" => $report, "form" => $form->createView()]);
    }

    /**
     * @Route("/delete/{id}", name="delete")
     *
     * @param $id
     * @param Request $request
     * @return \Symfony\Component\HttpFoundation\Response
     */
    public function delete($id, Request $request)
    {
        $repo = $this->getDoctrine()->getRepository(Report::class);
        $report = $repo->find($id);
        if ($report == null) {
            return $this->redirect("/");
        }
        $form = $this->createForm(ReportType::class, $report);
        $form->handleRequest($request);
        if ($form->isSubmitted()) {
            $em = $this->getDoctrine()->getManager();
            $em->remove($report);
            $em->flush();
            return $this->redirect("/");
        }
        return $this->render(
            "report/delete.html.twig",
            ["report" => $report, "form" => $form->createView()]
        );
    }
}
