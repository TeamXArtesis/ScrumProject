package com.teamx.dao;

import java.util.List;

import com.teamx.domain.Olod;

public interface OlodDao {
	public List<Olod> findAll();
	public Olod findDocentById(int id);
	public void create(Olod olod);
	public void delete(int id);
	public void delete(Olod olod);
}
