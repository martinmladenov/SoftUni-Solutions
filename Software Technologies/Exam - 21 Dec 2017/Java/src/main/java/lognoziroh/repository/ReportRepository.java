package lognoziroh.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import lognoziroh.entity.Report;

public interface ReportRepository extends JpaRepository<Report, Integer> {
}
